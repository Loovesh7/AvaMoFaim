using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using MoFaim.Models;
using MoFaim.Views;
using MoFaim.ViewModels;
using System.IO;
using System.Collections;

namespace MoFaim.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AdminItemsPage : ContentPage
    {
        AdminItemsViewModel viewModel;

        public AdminItemsPage()
        {
            InitializeComponent();

            BindingContext = viewModel = new AdminItemsViewModel();
        }

        async void AddItem_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new NavigationPage(new NewItemPage()));
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            if (viewModel.AllItems.Count == 0)
                viewModel.LoadItemsCommand.Execute(null);
        }


        private void SearchBar_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (string.IsNullOrEmpty(e.NewTextValue))
            {
                ItemsListView.ItemsSource = viewModel.AllItems;
            }

            else
            {
                ItemsListView.ItemsSource = viewModel.AllItems.Where(x => x.LastName.ToLower().StartsWith(e.NewTextValue.ToLower()) || x.FirstName.ToLower().StartsWith(e.NewTextValue.ToLower()));
            }
        }


    }

}