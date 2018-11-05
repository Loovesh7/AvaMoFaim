using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Windows.Input;
using MoFaim.Models;
using MonkeyCache.SQLite;
using MvvmHelpers;
using Xamarin.Forms;

namespace MoFaim.ViewModels
{
    public class ItemDetailViewModel : BaseViewModel
    {
        public Restaurants Item { get; set; }
        public ObservableRangeCollection<MenuItems> MenuItems { get; set; }
        public Command LoadItemsCommand { get; set; }
        public static double UserRating = 0.0;

        public ItemDetailViewModel(Restaurants item = null)
        {
            Title = item?.Name;
            Item = item;
           
            MenuItems = new ObservableRangeCollection<MenuItems>();
            MenuItems menu = new MenuItems("Need to Refresh Page",0.00, "Restart App");
            MenuItems.Add(menu);

            LoadMenus(item.Id);

            CallCommand = new Command(OnCall);
            Services.StarBehavior.GroupNameResto = Item.Name;
            RateCommand = new Command(OnRateAsync);
        }

        public ICommand CallCommand { protected set; get; }
        public ICommand RateCommand { protected set; get; }

        public void OnCall()
        {
            Device.OpenUri(new Uri("tel:" + Item.Phone));
        }

        public async void OnRateAsync()
        {
            int UserId = (int) App.Current.Properties["UserId"];
            //Services.StarBehavior.count = 0;
           UserRatingDto userRatingDto = new UserRatingDto(UserId, Item.Id, UserRating);

            await Services.MonkeyCache.RateRestaurantAsync(userRatingDto);

        }

        public void LoadMenus(int restaurantId)
        {

            if (!Barrel.Current.IsExpired(key: Services.MonkeyCache.menuItemsKey))
            {
                IEnumerable<MenuItems> menuItems = Barrel.Current.Get<IEnumerable<MenuItems>>(key: Services.MonkeyCache.menuItemsKey);
                ObservableRangeCollection<MenuItems> restaurantMenus = new ObservableRangeCollection<MenuItems>();
                foreach (MenuItems m in menuItems)
                {
                    if (m.RestaurantId == restaurantId)
                    {
                        restaurantMenus.Add(m);
                    }
                }
                MenuItems.ReplaceRange(restaurantMenus);
            }

            foreach (MenuItems m in MenuItems)
            {
                Console.WriteLine("-------------------Call API for Menus  " + m.Name);
            }
        }

    }
}