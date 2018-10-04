using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MoFaimWebService.Entities
{
    public class Restaurants
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }
        public string Phone { get; set; }
        public string Details { get; set; }
        public string Logo { get; set; }
        public double Rating { get; set; }
    }
}
