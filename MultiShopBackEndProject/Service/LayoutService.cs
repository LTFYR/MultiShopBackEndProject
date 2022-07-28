using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using MultiShopBackEndProject.DAL;
using MultiShopBackEndProject.Models;
using MultiShopBackEndProject.ViewModels;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;

namespace MultiShopBackEndProject.Service
{
    public class LayoutService
    {
        private readonly AppDbContext _context;
        private readonly IHttpContextAccessor _httpContext;

        public LayoutService(AppDbContext context,IHttpContextAccessor httpContext)
        {
            _context = context;
            _httpContext = httpContext;
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
            string basketStr = _httpContext.HttpContext.Request.Cookies["Cart"];
            if (!string.IsNullOrEmpty(basketStr))
            {
                BasketVM basket = JsonConvert.DeserializeObject<BasketVM>(basketStr);
                LayoutBasketVM layoutBasketVM = new LayoutBasketVM();
                layoutBasketVM.basketItemVMs = new List<BasketItemVM>();
                foreach (BasketCookieItemVM item in basket.basketCookieItemVMs)
                {
                    Clothe current = _context.Clothes.Include(c=>c.ClotheImages).FirstOrDefault(c=>c.Id == item.Id);
                    if(current == null)
                    {
                        basket.basketCookieItemVMs.Remove(item);
                        continue;
                    }
                    BasketItemVM basketItemVM = new BasketItemVM
                    {
                        Clothe = current,
                        Quantity = item.Quantity,
                        Subtotal = (current.Price * item.Quantity),
                        //Total = 
                    };
                    layoutBasketVM.basketItemVMs.Add(basketItemVM);
                }
                layoutBasketVM.TotalPrice = basket.Totalprice;
                return layoutBasketVM;
            }
            return null;
        }
    }
}
