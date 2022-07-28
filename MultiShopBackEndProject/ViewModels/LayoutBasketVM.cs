using System.Collections.Generic;

namespace MultiShopBackEndProject.ViewModels
{
    public class LayoutBasketVM
    {
        public List<BasketItemVM> basketItemVMs { get; set; }
        public decimal TotalPrice { get; set; }
    }
}
