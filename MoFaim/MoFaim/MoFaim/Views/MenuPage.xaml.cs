using MoFaim.Models;
using System;
using System.Collections.Generic;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MoFaim.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MenuPage : ContentPage
    {
        string role = (string)App.Current.Properties["UserRole"];

        List<HomeMenuItem> menuItems;
        public MenuPage()
        {
            InitializeComponent();

            menuItems = checkUser();

            ListViewMenu.ItemsSource = menuItems;
            
            ListViewMenu.SelectedItem = menuItems[0];

            ListViewMenu.ItemSelected += async (sender, e) =>
            {
                if (e.SelectedItem == null)
                    return;

                var id = (int)((HomeMenuItem)e.SelectedItem).Id;

                if (role.Equals("Admin"))
                {
                    AdminPage RootPage = Application.Current.MainPage as AdminPage;
                    await RootPage.NavigateFromMenu(id);
                }
                else
                {
                    MainPage RootPage = Application.Current.MainPage as MainPage;
                    await RootPage.NavigateFromMenu(id);
                }
            };
        }

        public List<HomeMenuItem> checkUser()
        {
            List<HomeMenuItem> menuItems;
            
            if (role.Equals("Admin"))
            {
                menuItems = new List<HomeMenuItem>
                {
                new HomeMenuItem {Id = MenuItemType.Users, Title="Users" },
                new HomeMenuItem {Id = MenuItemType.Restaurants, Title="Restaurants" },
                new HomeMenuItem {Id = MenuItemType.About, Title="About" },
                new HomeMenuItem {Id = MenuItemType.Logout, Title="Logout" }
                };
            }
            else {
                menuItems = new List<HomeMenuItem>
                {
                new HomeMenuItem {Id = MenuItemType.Restaurants, Title="Restaurants" },
                new HomeMenuItem {Id = MenuItemType.About, Title="About" },
                new HomeMenuItem {Id = MenuItemType.Logout, Title="Logout" }
                };
            }
            return menuItems;
        }

    }
}