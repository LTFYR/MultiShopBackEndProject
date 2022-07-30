using MultiShopBackEndProject.Models.Base;

namespace MultiShopBackEndProject.Models
{
    public class BasketItem:BaseEntity
    {
        public int ClotheId { get; set; }
        public Clothe Clothe { get; set; }
        public int ColorId { get; set; }
        public int SizeId { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        public string AppUserId { get; set; }
        public AppUser AppUser { get; set; }
    }
}
