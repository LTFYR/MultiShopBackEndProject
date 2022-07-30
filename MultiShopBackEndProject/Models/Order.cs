using MultiShopBackEndProject.Models.Base;
using System;
using System.Collections.Generic;

namespace MultiShopBackEndProject.Models
{
    public class Order:BaseEntity
    {
        public DateTime dateTime { get; set; }
        public AppUser AppUser { get; set; }
        public int? UserId { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        public List<BasketItem> BasketItems { get; set; }
        public bool? Status { get; set; }
        public string Location { get; set; }
    }
}
