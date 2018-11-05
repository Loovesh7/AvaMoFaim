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
    public partial class ItemsPage : ContentPage
    {
        ItemsViewModel viewModel;

        public ItemsPage()
        {
            InitializeComponent();

            BindingContext = viewModel = new ItemsViewModel();
        }

        async void OnItemSelected(object sender, SelectedItemChangedEventArgs args)
        {
            var item = args.SelectedItem as Restaurants;
            if (item == null)
                return;

            //Store Restaurant Id of selected Restaurant
            App.Current.Properties["RestaurantId"] = item.Id;

            await Navigation.PushAsync(new ItemDetailPage(new ItemDetailViewModel(item)));

            // Manually deselect item.
            ItemsListView.SelectedItem = null;
        }

        async void AddItem_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new NavigationPage(new NewItemPage()));
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            if (viewModel.Items.Count == 0)
                viewModel.LoadItemsCommand.Execute(null);
        }

        public void setImage(string jsonString)
        {
            Item item = Newtonsoft.Json.JsonConvert.DeserializeObject<Item>(jsonString);
            ImageSource imageSource = ImageSource.FromStream(() => new MemoryStream(item.Logo));
            var image = new Image { Aspect = Aspect.AspectFit };
            image.Source = imageSource;
            
        }

        private void SearchBar_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (string.IsNullOrEmpty(e.NewTextValue))
            {
                ItemsListView.ItemsSource = viewModel.Items;
            }

            else
            {
                ItemsListView.ItemsSource = viewModel.Items.Where(x => x.Name.ToLower().StartsWith(e.NewTextValue.ToLower()) || x.Location.ToLower().StartsWith(e.NewTextValue.ToLower()));
            }
        }


    }

}