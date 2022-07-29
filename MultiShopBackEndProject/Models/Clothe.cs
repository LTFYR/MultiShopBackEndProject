using Microsoft.AspNetCore.Http;
using MultiShopBackEndProject.Models.Base;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace MultiShopBackEndProject.Models
{
    public class Clothe:BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public string Image { get; set; }
        public int ClotheDescriptionId { get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; }
        //public int DiscountedPriceId { get; set; }
        //public DiscountedPrice DiscountedPrice { get; set; }
        public ClotheDescription ClotheDescription { get; set; }
        public int ClotheInformationId { get; set; }
        public ClotheInformation ClotheInformation { get; set; }
        public List<ClotheImage> ClotheImages { get; set; }
        [NotMapped]
        public List<IFormFile> Photos { get; set; }
        [NotMapped]
        public IFormFile Main { get; set; }
        [NotMapped]
        public List<int> ImagesId { get; set; }
    }
}
