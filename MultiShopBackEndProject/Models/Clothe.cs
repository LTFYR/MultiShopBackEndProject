using MultiShopBackEndProject.Models.Base;
using System.Collections.Generic;

namespace MultiShopBackEndProject.Models
{
    public class Clothe:BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public string Image { get; set; }
        public int ClotheDescriptionId { get; set; }
        public ClotheDescription ClotheDescription { get; set; }
        public int ClotheInformationId { get; set; }
        public ClotheInformation ClotheInformation { get; set; }
        public List<ClotheImage> ClotheImages { get; set; }
        public List<ClotheCategory> ClotheCategories { get; set; }
    }
}
