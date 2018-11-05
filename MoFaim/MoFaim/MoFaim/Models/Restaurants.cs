using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace MoFaim.Models
{
    public class Restaurants
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }
        public string Phone { get; set; }
        public string Details { get; set; }
        public byte[] Logo { get; set; }
        public double Rating { get; set; }

        [JsonIgnore]
        public ImageSource ImageSource { get; set; }
    }
}
