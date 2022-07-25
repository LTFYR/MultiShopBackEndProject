using MultiShopBackEndProject.Models.Base;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MultiShopBackEndProject.Models
{
    public class Category:BaseEntity
    {
        [Required,StringLength(maximumLength:20)]
        public string Name { get; set; }
        public string Image { get; set; }
        public int Quantity { get; set; }
        List<ClotheCategory> ClotheCategories { get; set; }
    }
}
