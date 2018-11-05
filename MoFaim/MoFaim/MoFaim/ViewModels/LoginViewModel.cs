using MoFaim.Models;
using MoFaim.Services;
using MoFaim.Views;
using Refit;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace MoFaim.ViewModels
{
    public class LoginViewModel : INotifyPropertyChanged
    {
        public Action DisplayInvalidLoginPrompt;
        public Action DisplayLoginFailedPrompt;
        public event PropertyChangedEventHandler PropertyChanged = delegate { };
        private Page Page { get; set; }
        private int i = 0;

        private string email;
        public string Email
        {
            get { return email; }
            set
            {
                email = value;
                PropertyChanged(this, new PropertyChangedEventArgs("Email"));
            }
        }
        private string password;
        public string Password
        {
            get { return password; }
            set
            {
                password = value;
                PropertyChanged(this, new PropertyChangedEventArgs("Password"));
            }
        }
        public ICommand SubmitCommand { protected set; get; }
        public ICommand RegisterCommand { protected set; get; }

        public LoginViewModel(Page page)
        {
            this.Page = page;
            SubmitCommand = new Command(OnSubmitAsync);
            RegisterCommand = new Command(OnRegisterAsync);
        }

        public async void OnRegisterAsync()
        {
            await Page.Navigation.PushAsync(new RegistrationPage());
        }

        public async void OnSubmitAsync()
        {
            i++;
            UserDTO userDTO = new UserDTO(email,password);
            try
            {
                await CallApi(userDTO);
            } catch(HttpRequestException e)
            {
                Console.WriteLine("HttpRequestException: "+e.Message);
                if(i<4)
                    OnSubmitAsync();
            }

            DisplayLoginFailedPrompt();

        }

        async Task CallApi(UserDTO user)
        {
            var apiService = RestService.For<IMoFaimApi>("https://mofaimwebserviceaavs.azurewebsites.net/");
            var apiResponse = await apiService.ValidateUser(user);

            if (apiResponse.IsSuccessStatusCode)
            {
                AuthenticateUser loginUser = apiResponse.Content;
                App.Current.Properties["jwtToken"] = loginUser.Token;
                App.Current.Properties["UserRole"] = loginUser.Role;
                App.Current.Properties["UserName"] = loginUser.FirstName;
                App.Current.Properties["UserId"] = loginUser.Id;
                App.IsUserLoggedIn = true;
                if (loginUser.Role.Equals("Admin"))
                {
                    Console.WriteLine("----Admin---------------------------"+loginUser.Id);
                    Application.Current.MainPage = new AdminPage();
                    await Page.Navigation.PushAsync(new AdminPage());
                    await Services.MonkeyCache.GetUsersAsync();
                    await Services.MonkeyCache.GetRestaurantsAsync();
                    await Services.MonkeyCache.GetMenuItemsAsync();
                }
                else
                {
                    Application.Current.MainPage = new MainPage();
                    await Page.Navigation.PushAsync(new MainPage());
                    await Services.MonkeyCache.GetRestaurantsAsync();
                    await Services.MonkeyCache.GetMenuItemsAsync();
                }
            }
            else
            {
                DisplayInvalidLoginPrompt();
            }
           
        }

        void ValidateUserEntries()
        {
            if(email.Equals("") || password.Equals(""))
            {
                
            }
        }
    }
}
