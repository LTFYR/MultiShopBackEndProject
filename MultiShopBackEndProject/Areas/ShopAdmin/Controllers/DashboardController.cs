using Microsoft.AspNetCore.Mvc;
using MultiShopBackEndProject.DAL;
using MultiShopBackEndProject.Models;
using System.Collections.Generic;
using System.Linq;
using X.PagedList;

namespace MultiShopBackEndProject.Areas.ShopAdmin.Controllers
{
    [Area("ShopAdmin")]

    public class DashboardController : Controller
    {
        private readonly AppDbContext _context;


        public DashboardController(AppDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            List<Contact> contact = _context.Contacts.ToList();
            return View(contact);
        }

    }
}
