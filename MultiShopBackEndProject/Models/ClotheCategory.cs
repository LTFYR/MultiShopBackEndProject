using MultiShopBackEndProject.Models.Base;

namespace MultiShopBackEndProject.Models
{
    public class ClotheCategory:BaseEntity
    {
        public int CategoryId { get; set; }
        public Category Category { get; set; }
        public int ClotheId { get; set; }
        public Clothe Clothe { get; set; }
    }
}
