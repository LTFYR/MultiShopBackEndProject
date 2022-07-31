using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MultiShopBackEndProject.DAL;
using MultiShopBackEndProject.Models;
using MultiShopBackEndProject.ViewModels;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MultiShopBackEndProject.Controllers
{
    public class CartController : Controller
    {
        private readonly AppDbContext _context;
        private readonly UserManager<AppUser> _userManager;

        public CartController(AppDbContext context, UserManager<AppUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }
        public IActionResult Index()
        {
            return View();
        }   
        public async Task<IActionResult> AddCart(int? id)
        {
            if (id == null || id == 0) return NotFound();
            Clothe clothe = await _context.Clothes.FirstOrDefaultAsync(c => c.Id == id);
            //Color color = await _context.Colors.FirstOrDefaultAsync(c => c.Id == id);
            //Size size = await _context.Sizes.FirstOrDefaultAsync(c => c.Id == id);
            if (clothe == null) return NotFound();
            if (User.Identity.IsAuthenticated && User.IsInRole("Member"))
            {
                AppUser user = await _userManager.FindByNameAsync(User.Identity.Name);
                BasketItem current = await _context.BasketItems.FirstOrDefaultAsync(b => b.AppUserId == user.Id && b.ClotheId == clothe.Id);
                if (current == null)
                {
                    current = new BasketItem
                    {
                        Clothe = clothe,
                        AppUser = user,
                        Quantity = 1,
                        Price = clothe.Price,
                        //Color = color,
                        //Size = size
                    };
                    _context.BasketItems.Add(current);
                }
                else
                {
                    current.Quantity++;
                }
                await _context.SaveChangesAsync();
            }
            else
            {
                string basketStr = HttpContext.Request.Cookies["Cart"];

                BasketVM basketVM;
                if (string.IsNullOrEmpty(basketStr))
                {
                    basketVM = new BasketVM();
                    BasketCookieItemVM basketCookieItemVM = new BasketCookieItemVM
                    {
                        Id = clothe.Id,
                        Quantity = 1
                    };
                    basketVM.basketCookieItemVMs = new List<BasketCookieItemVM>();
                    basketVM.basketCookieItemVMs.Add(basketCookieItemVM);
                    basketVM.Totalprice = clothe.Price;
                    basketVM.Totalprice = (clothe.Price * basketCookieItemVM.Quantity);
                }
                else
                {
                    basketVM = JsonConvert.DeserializeObject<BasketVM>(basketStr);
                    BasketCookieItemVM current = basketVM.basketCookieItemVMs.Find(c => c.Id == id);
                    if(current == null)
                    {
                        BasketCookieItemVM cookieItemVM = new BasketCookieItemVM
                        {
                            Id = clothe.Id,
                            Quantity = 1
                        };
                        basketVM.basketCookieItemVMs.Add(cookieItemVM);
                        basketVM.Totalprice += clothe.Price;
                    }
                    else
                    {
                        basketVM.Totalprice += clothe.Price;
                        current.Quantity++;
                        
                    }
                }
                basketStr = JsonConvert.SerializeObject(basketVM);
                HttpContext.Response.Cookies.Append("Cart", basketStr);
            }
            return RedirectToAction("Index", "Cart");
        }

        public async Task<IActionResult> Plus(int? id)
        {
            if (id == null || id == 0) return NotFound();
            Clothe clothe = await _context.Clothes.FirstOrDefaultAsync(p => p.Id == id);
            if (clothe == null) return NotFound();
            if (User.Identity.IsAuthenticated)
            {
                AppUser user = await _userManager.FindByNameAsync(User.Identity.Name);
                BasketItem current = await _context.BasketItems.FirstOrDefaultAsync(b => b.AppUserId == user.Id && b.ClotheId == clothe.Id);
                if (current == null)
                {
                    current = new BasketItem
                    {
                        Clothe = clothe,
                        AppUser = user,
                        Quantity = 1,
                        Price = clothe.Price
                    };
                    _context.BasketItems.Add(current);
                }
                else
                {
                    current.Quantity++;
                }
                await _context.SaveChangesAsync();
            }
            else
            {
                string basketStr = HttpContext.Request.Cookies["Cart"];

                BasketVM basketVM;
                if (string.IsNullOrEmpty(basketStr))
                {
                    basketVM = new BasketVM();
                    BasketCookieItemVM basketCookieItemVM = new BasketCookieItemVM
                    {
                        Id = clothe.Id,
                        Quantity = 1
                    };
                    basketVM.basketCookieItemVMs = new List<BasketCookieItemVM>();
                    basketVM.basketCookieItemVMs.Add(basketCookieItemVM);
                    basketVM.Totalprice = clothe.Price;
                    basketVM.Totalprice = (clothe.Price * basketCookieItemVM.Quantity);
                }
                else
                {
                    basketVM = JsonConvert.DeserializeObject<BasketVM>(basketStr);
                    BasketCookieItemVM current = basketVM.basketCookieItemVMs.Find(c => c.Id == id);
                    if (current == null)
                    {
                        BasketCookieItemVM cookieItemVM = new BasketCookieItemVM
                        {
                            Id = clothe.Id,
                            Quantity = 1
                        };
                        basketVM.basketCookieItemVMs.Add(cookieItemVM);
                        basketVM.Totalprice += clothe.Price;
                    }
                    else
                    {
                        basketVM.Totalprice += clothe.Price;
                        current.Quantity++;

                    }
                }
                basketStr = JsonConvert.SerializeObject(basketVM);
                HttpContext.Response.Cookies.Append("Cart", basketStr);
            }
            return RedirectToAction("Index", "Cart");
        }


        public async Task<IActionResult> Minus(int? id)
        {
            if (id == null || id == 0) return NotFound();
            Clothe clothe = await _context.Clothes.FirstOrDefaultAsync(p => p.Id == id);
            if (clothe == null) return NotFound();
            if (User.Identity.IsAuthenticated)
            {
                AppUser user = await _userManager.FindByNameAsync(User.Identity.Name);
                BasketItem current = await _context.BasketItems.FirstOrDefaultAsync(b => b.AppUserId == user.Id && b.ClotheId == clothe.Id);
                if (current == null)
                {
                    current = new BasketItem
                    {
                        Clothe = clothe,
                        AppUser = user,
                        Quantity = 1,
                        Price = clothe.Price
                    };
                    _context.BasketItems.Add(current);
                }
                else
                {
                    current.Quantity--;
                }
                await _context.SaveChangesAsync();
            }
            else
            {
                string basketStr = HttpContext.Request.Cookies["Cart"];

                BasketVM basketVM;
                if (string.IsNullOrEmpty(basketStr))
                {
                    basketVM = new BasketVM();
                    BasketCookieItemVM basketCookieItemVM = new BasketCookieItemVM
                    {
                        Id = clothe.Id,
                        Quantity = 1
                    };
                    basketVM.basketCookieItemVMs = new List<BasketCookieItemVM>();
                    basketVM.basketCookieItemVMs.Add(basketCookieItemVM);
                    basketVM.Totalprice = clothe.Price;
                    basketVM.Totalprice = (clothe.Price * basketCookieItemVM.Quantity);
                }
                else
                {
                    basketVM = JsonConvert.DeserializeObject<BasketVM>(basketStr);
                    BasketCookieItemVM current = basketVM.basketCookieItemVMs.Find(c => c.Id == id);
                    if (current == null)
                    {
                        BasketCookieItemVM cookieItemVM = new BasketCookieItemVM
                        {
                            Id = clothe.Id,
                            Quantity = 1
                        };
                        basketVM.basketCookieItemVMs.Add(cookieItemVM);
                        basketVM.Totalprice += clothe.Price;
                    }
                    else
                    {
                        basketVM.Totalprice += clothe.Price;
                        current.Quantity--;

                    }
                }
                basketStr = JsonConvert.SerializeObject(basketVM);
                HttpContext.Response.Cookies.Append("Cart", basketStr);
            }
            return RedirectToAction("Index", "Cart");
        }

        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0) return NotFound();
            Clothe clothe = _context.Clothes.FirstOrDefault(c => c.Id == id);
            if (clothe == null) return NotFound();
            string basketSTR = HttpContext.Request.Cookies["Cart"];
            BasketVM basketVM = JsonConvert.DeserializeObject<BasketVM>(basketSTR);
            BasketCookieItemVM exist = basketVM.basketCookieItemVMs.FirstOrDefault(c=>c.Id == id);
            basketVM.basketCookieItemVMs.Remove(exist);
            exist.Quantity = 0;
            basketVM.Totalprice -= clothe.Price;
            basketSTR = JsonConvert.SerializeObject(basketVM);
            HttpContext.Response.Cookies.Append("Cart",basketSTR);
            return RedirectToAction("Index", "Cart");
        }
    }
}
