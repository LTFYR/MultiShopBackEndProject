using MultiShopBackEndProject.Models.Base;
using System.Collections.Generic;

namespace MultiShopBackEndProject.Models
{
    public class DiscountedPrice:BaseEntity
    {
        public int DiscountPrice { get; set; }
        public List<Clothe> Clothes { get; set; }
    }
}
