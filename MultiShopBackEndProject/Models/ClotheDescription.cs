using MultiShopBackEndProject.Models.Base;
using System.Collections.Generic;

namespace MultiShopBackEndProject.Models
{
    public class ClotheDescription:BaseEntity
    {
        public string Description { get; set; }
        public List<Clothe> Clothes { get; set; }
    }
}
