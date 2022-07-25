using MultiShopBackEndProject.Models.Base;

namespace MultiShopBackEndProject.Models
{
    public class BasketItem:BaseEntity
    {
        public int ClotheId { get; set; }
        public Clothe Clothe { get; set; }
        public int ColorId { get; set; }
        public Color Color { get; set; }
        public int SizeId { get; set; }
        public Size Size { get; set; }
    }
}
