﻿using MoFaim.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace MoFaim.Services
{
    public class RatingConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            var rating = (int)value;

            //set rating in view model
            ItemDetailViewModel.UserRating = (int) value;

            Console.WriteLine("===================RATE=======" + rating);

            if (rating == 1)
                return "Disappointed!";
            if (rating == 2)
                return "Not a fan!";
            if (rating == 3)
                return "It's Ok!";
            if (rating == 4)
                return "Like it!";
            if (rating == 5)
                return "Love it!";

            return string.Empty;
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}