﻿using System.ComponentModel.DataAnnotations;

namespace GeekShopping.Web.Models
{
    public class ProductModel
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string Description { get; set; }
        public string CategoryName { get; set; }
        public string ImageURL { get; set; }

        [Range(1, 100)]
        public int Count { get; set; } = 1;

        public string SubStringName()
        {
            if (Name.Length < 20) return Name;
            return $"{Name.Substring(0, 17)}...";
        }
        public string SubStringDescription()
        {
            if (Description.Length < 255) return Description;
            return $"{Description.Substring(0, 252)}...";
        }
    }
}
