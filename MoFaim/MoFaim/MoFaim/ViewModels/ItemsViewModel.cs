using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;

using Xamarin.Forms;

using MoFaim.Models;
using MoFaim.Views;
using MvvmHelpers;
using System.Linq;
using System.Collections.Generic;
using System.IO;

namespace MoFaim.ViewModels
{
    public class ItemsViewModel : BaseViewModel
    {
        public ObservableRangeCollection<Restaurants> Items { get; set; }
        public Command LoadItemsCommand { get; set; }


        public ItemsViewModel()
        {
            Title = "Restaurants";
            Items = new ObservableRangeCollection<Restaurants>();

            LoadItemsCommand = new Command(async () => await ExecuteLoadItemsCommand());
        }

        async Task ExecuteLoadItemsCommand()
        {
            if (IsBusy)
                return;

            IsBusy = true;

            try
            {
                Items.Clear();
                var items = await Services.MonkeyCache.GetRestaurantsAsync();
                foreach (Restaurants r in items)
                {
                    r.ImageSource = ImageSource.FromStream(() => new MemoryStream(r.Logo));
                    Console.WriteLine("----IMAGE*********----" + r.ImageSource);
                }
                Items.ReplaceRange(items);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
            finally
            {
                IsBusy = false;
            }
        }
    }
}