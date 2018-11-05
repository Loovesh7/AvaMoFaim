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

namespace MoFaim.ViewModels
{
    public class AdminItemsViewModel : BaseViewModel
    {
        public ObservableRangeCollection<UserDTO> AllItems { get; set; }
        public Command LoadItemsCommand { get; set; }

        public AdminItemsViewModel()
        {
            Title = "Users";
            AllItems = new ObservableRangeCollection<UserDTO>();

            LoadItemsCommand = new Command(async () => await ExecuteLoadItemsCommand());
        }


        async Task ExecuteLoadItemsCommand()
        {
            if (IsBusy)
                return;

            IsBusy = true;

            try
            {
                AllItems.Clear();
                var items = await Services.MonkeyCache.GetUsersAsync();
                foreach (UserDTO u in items)
                {
                    u.FullName = u.FirstName + " " + u.LastName;
                    if(u.RoleId == 1)
                    {
                        u.Role = "Admin";
                    }
                    else
                    {
                        u.Role = "Normal User";
                    }
                   
                }
                AllItems.ReplaceRange(items);
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