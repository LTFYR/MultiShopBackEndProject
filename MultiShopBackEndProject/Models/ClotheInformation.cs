using MultiShopBackEndProject.Models.Base;
using System.Collections.Generic;

namespace MultiShopBackEndProject.Models
{
    public class ClotheInformation:BaseEntity
    {
        public string Information { get; set; }
        public List<Clothe> Clothes { get; set; }
    }
}
