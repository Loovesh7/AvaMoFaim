using MoFaim.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MoFaim.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class RegistrationPage : ContentPage
    {
        public RegistrationPage()
        {
            var scroll = new ScrollView();
            Content = scroll;
            var rvm = new RegistrationViewModel(this);
            this.BindingContext = rvm;
            rvm.DisplayInvalidLoginPrompt += () => DisplayAlert("Error", "Username or Password Already Exist, try again", "OK");

            InitializeComponent();

            FirstName.Completed += (object sender, EventArgs e) =>
            {
                LastName.Focus();
            };

            LastName.Completed += (object sender, EventArgs e) =>
            {
                Email.Focus();
            };

            Email.Completed += (object sender, EventArgs e) =>
            {
                Password.Focus();
            };

            Password.Completed += (object sender, EventArgs e) =>
            {
                ConfirmPassword.Focus();
            };

            ConfirmPassword.Completed += (object sender, EventArgs e) =>
            {
                rvm.SubmitCommand.Execute(null);
            };
        }
    }
}
