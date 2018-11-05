using MoFaim.Models;
using MoFaim.Services;
using MoFaim.Views;
using Refit;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace MoFaim.ViewModels
{
    class RegistrationViewModel : INotifyPropertyChanged
    {
        public Action DisplayInvalidLoginPrompt;
        public event PropertyChangedEventHandler PropertyChanged = delegate { };
        private Page Page { get; set; }

        private string firstName;
        public string FirstName
        {
            get { return firstName; }
            set
            {
                firstName = value;
                PropertyChanged(this, new PropertyChangedEventArgs("FirstName"));
            }
        }

        private string lastName;
        public string LastName
        {
            get { return lastName; }
            set
            {
                lastName = value;
                PropertyChanged(this, new PropertyChangedEventArgs("LastName"));
            }
        }

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

        private string confirmPassword;
        public string ConfirmPassword
        {
            get { return confirmPassword; }
            set
            {
                confirmPassword = value;
                PropertyChanged(this, new PropertyChangedEventArgs("ConfirmPassword"));
            }
        }

        public ICommand SubmitCommand { protected set; get; }

        public RegistrationViewModel(Page page)
        {
            this.Page = page;
            SubmitCommand = new Command(OnSubmitAsync);
        }

        public async void OnSubmitAsync()
        {
            UserDTO userDTO = new UserDTO(firstName, lastName, email, password);
            await CallApi(userDTO);
        }

        async Task CallApi(UserDTO user)
        {
            var apiService = RestService.For<IMoFaimApi>("https://mofaimwebserviceaavs.azurewebsites.net/");
            var apiResponse = await apiService.RegisterUser(user);

            if (apiResponse.IsSuccessStatusCode)
            {
                AuthenticateUser loginUser = apiResponse.Content;
                App.Current.Properties["jwtToken"] = loginUser.Token;
                App.Current.Properties["UserRole"] = loginUser.Role;
                App.Current.Properties["UserName"] = loginUser.FirstName;
                App.Current.Properties["UserId"] = loginUser.Id;
                Application.Current.MainPage = new MainPage();
                await Page.Navigation.PushAsync(new MainPage());
            }
            else
            {
                DisplayInvalidLoginPrompt();
            }

        }

        void ValidateUserEntries()
        {

        }
    }
}

