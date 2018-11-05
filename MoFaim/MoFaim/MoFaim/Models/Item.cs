using System;

namespace MoFaim.Models
{
    public class Item
    {
        public string Id { get; set; }
        public string Text { get; set; }
        public string Location { get; set; }
        public string Description { get; set; }
        public byte[] Logo { get; set; }
    }
}