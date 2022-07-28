using MultiShopBackEndProject.Models;

namespace MultiShopBackEndProject.ViewModels
{
    public class BasketItemVM
    {
        public Clothe Clothe { get; set; }
        public int Quantity { get; set; }
        public decimal Subtotal { get; set; }
        public decimal Total { get; set;}
    }
}
