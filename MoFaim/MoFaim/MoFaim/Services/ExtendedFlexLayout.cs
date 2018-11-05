using MoFaim.Models;
using MvvmHelpers;
using System.Collections;
using Xamarin.Forms;

namespace MoFaim.Services
{
    public class ExtendedFlexLayout : FlexLayout
    {
        public static readonly BindableProperty ItemsSourceProperty = BindableProperty.Create(nameof(ItemsSource), typeof(ObservableRangeCollection<MenuItems>), typeof(ExtendedFlexLayout), propertyChanged: OnItemsSourceChanged);
        public static readonly BindableProperty ItemTemplateProperty = BindableProperty.Create(nameof(ItemTemplate), typeof(DataTemplate), typeof(ExtendedFlexLayout));

        public ObservableRangeCollection<MenuItems> ItemsSource
        {
            get { return (ObservableRangeCollection<MenuItems>)GetValue(ItemsSourceProperty); }
            set { SetValue(ItemsSourceProperty, value); }
        }

        public DataTemplate ItemTemplate
        {
            get { return (DataTemplate)GetValue(ItemTemplateProperty); }
            set { SetValue(ItemTemplateProperty, value); }
        }

        static void OnItemsSourceChanged(BindableObject bindable, object oldVal, object newVal)
        {
            ObservableRangeCollection<MenuItems> newValue = newVal as ObservableRangeCollection<MenuItems>;
            var layout = (ExtendedFlexLayout)bindable;

            layout.Children.Clear();
            if (newValue != null)
            {
                foreach (var item in newValue)
                {
                    layout.Children.Add(layout.CreateChildView(item));
                }
            }
        }

        View CreateChildView(object item)
        {
            ItemTemplate.SetValue(BindableObject.BindingContextProperty, item);
            return (View)ItemTemplate.CreateContent();
        }
    }
}
