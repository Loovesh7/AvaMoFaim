using System;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using MoFaim.Models;
using MoFaim.ViewModels;
using System.Collections;

namespace MoFaim.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ItemDetailPage : ContentPage
    {
        ItemDetailViewModel viewModel;

        public ItemDetailPage(ItemDetailViewModel viewModel)
        {
            InitializeComponent();

            BindingContext = this.viewModel = viewModel;
        }

    }

    
}