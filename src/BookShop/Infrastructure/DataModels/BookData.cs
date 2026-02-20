using System;
using System.Collections.Generic;
using System.Text;

namespace BookShop.Infrastructure.DataModels
{
    public class BookData
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Price { get; set; }
        public string Author { get; set; }
        public int Year { get; set; }
        public int Pages { get; set; }
    }
}
