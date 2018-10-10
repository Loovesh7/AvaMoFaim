using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MoFaimWebService.Dtos
{
    public class UploadRestaurantImageDto
    {
        public int RestaurantId { get;set; }
        public string Path { get; set; }
    }
}