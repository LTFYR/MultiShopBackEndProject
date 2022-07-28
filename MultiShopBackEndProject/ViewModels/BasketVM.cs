using System.Collections.Generic;

namespace MultiShopBackEndProject.ViewModels
{
    public class BasketVM
    {
        public List<BasketCookieItemVM> basketCookieItemVMs { get; set; }
        public decimal Totalprice { get; set; }
    }
}
