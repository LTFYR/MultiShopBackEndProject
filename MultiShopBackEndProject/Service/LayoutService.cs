using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using MultiShopBackEndProject.DAL;
using MultiShopBackEndProject.Models;
using MultiShopBackEndProject.ViewModels;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MultiShopBackEndProject.Service
{
    public class LayoutService
    {
        private readonly AppDbContext _context;
        private readonly IHttpContextAccessor _httpContext;
        private readonly UserManager<AppUser> _userManager;

        public LayoutService(AppDbContext context, IHttpContextAccessor httpContext, UserManager<AppUser> userManager)
        {
            _context = context;
            _httpContext = httpContext;
            _userManager = userManager;
        }

        public List<Setting> Settings()
        {
            List<Setting> settings = _context.Settings.ToList();
            return settings;
        }

        public List<Category> Categories()
        {
            List<Category> categories = _context.Categories.ToList();
            return categories;
        }

        public LayoutBasketVM Basket()
        {
            LayoutBasketVM layoutBasketVM = new LayoutBasketVM();
            layoutBasketVM.basketItemVMs = new List<BasketItemVM>();
            if (!_httpContext.HttpContext.User.Identity.IsAuthenticated)
            {
                string basketStr = _httpContext.HttpContext.Request.Cookies["Cart"];
                if (!string.IsNullOrEmpty(basketStr))
                {
                    BasketVM basket = JsonConvert.DeserializeObject<BasketVM>(basketStr);
                    foreach (BasketCookieItemVM item in basket.basketCookieItemVMs)
                    {
                        Clothe current = _context.Clothes.Include(c => c.ClotheImages).FirstOrDefault(c => c.Id == item.Id);
                        if (current == null)
                        {
                            basket.basketCookieItemVMs.Remove(item);
                            continue;
                        }
                        BasketItemVM basketItemVM = new BasketItemVM
                        {
                            Clothe = current,
                            ClotheId = item.Id,
                            Quantity = item.Quantity,
                            Subtotal = (current.Price * item.Quantity)
                        };
                        layoutBasketVM.basketItemVMs.Add(basketItemVM);
                    }
                    layoutBasketVM.TotalPrice = basket.Totalprice;
                    return layoutBasketVM;
                }
            }
            {
                AppUser user =  _userManager.FindByNameAsync(_httpContext.HttpContext.User.Identity.Name).Result;
                List<BasketItem> basketItems = _context.BasketItems.Where(x => x.AppUserId == user.Id).Include(x => x.Clothe).ThenInclude(x => x.ClotheImages).ToList();

                if (basketItems.Count > 0)
                {

                    foreach (BasketItem item in basketItems)
                    {
                        BasketItemVM basketItemVM = new BasketItemVM
                        {
                            Clothe = item.Clothe,
                            ClotheId = item.ClotheId,
                            Quantity = item.Quantity,
                            Subtotal = (item.Price * item.Quantity)

                        };
                        layoutBasketVM.basketItemVMs.Add(basketItemVM);
                        layoutBasketVM.TotalPrice += item.Price;
                    };
                return layoutBasketVM;
                };

            }

          return null;
        }
    }
}
