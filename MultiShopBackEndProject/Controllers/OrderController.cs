using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MultiShopBackEndProject.DAL;
using MultiShopBackEndProject.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MultiShopBackEndProject.Controllers
{
    //[Authorize(Roles = "Member")]
    public class OrderController : Controller
    {
        private readonly AppDbContext _context;
        private readonly UserManager<AppUser> _userManager;

        public OrderController(AppDbContext context, UserManager<AppUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }
        public IActionResult Checkout()
        {
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> Checkout(Order order)
        {
            AppUser user = await _userManager.FindByNameAsync(User.Identity.Name);
            List<BasketItem> basket = await _context.BasketItems.Include(o=>o.AppUser)
                .Include(o=>o.Clothe)
                //.Include(o=>o.Color)
                //.Include(o=>o.Size)
                .Where(o=>o.AppUserId == user.Id).ToListAsync();
            order.dateTime = System.DateTime.Now;
            order.Status = null;
            order.Price = default;
            order.AppUser = user;
            order.Quantity = default;
            order.BasketItems = basket;
            foreach (BasketItem item in basket)
            {
                order.Quantity = basket.Count;
                order.Price += item.Price * item.Quantity;
            }
            await _context.Orders.AddAsync(order);
            await _context.SaveChangesAsync();

            return RedirectToAction("Index","Home");
        }
    }
}
