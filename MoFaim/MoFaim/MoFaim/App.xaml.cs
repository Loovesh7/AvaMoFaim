using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using MoFaim.Services;
using MoFaim.Views;
using MonkeyCache.SQLite;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using Newtonsoft.Json.Converters;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace MoFaim
{
    public partial class App : Application
    {

        //TODO: Replace with *.azurewebsites.net url after deploying backend to Azure
        public static string AzureBackendUrl = "http://localhost:5000";
        public static bool UseMockDataStore = true;

        public App()
        {
            InitializeComponent();

            Barrel.ApplicationId = "MoFaim" + DateTime.Now;

            if (UseMockDataStore)
                DependencyService.Register<MockDataStore>();
            else
                DependencyService.Register<AzureDataStore>();

            if (!IsUserLoggedIn)
                MainPage = new NavigationPage(new LoginPage());

            else
                MainPage = new MainPage();

        }

        protected override async void OnStart()
        {
            // Handle when your app starts
            // declare the global settings  
            JsonConvert.DefaultSettings = () => new JsonSerializerSettings()
            {
                ContractResolver = new CamelCasePropertyNamesContractResolver(),
                Converters = { new StringEnumConverter() }
            };

            if (IsUserLoggedIn)
            {
                await Services.MonkeyCache.GetMenuItemsAsync();
                await Services.MonkeyCache.GetRestaurantsAsync();
            }
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }

        // Use a service for providing this information
        public static bool IsUserLoggedIn { get; set; }
    }
}
