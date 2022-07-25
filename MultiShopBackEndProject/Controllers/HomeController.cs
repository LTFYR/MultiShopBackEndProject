using Microsoft.AspNetCore.Mvc;
using MultiShopBackEndProject.DAL;
using MultiShopBackEndProject.Models;
using System.Collections.Generic;
using System.Linq;

namespace MultiShopBackEndProject.Controllers
{
    public class HomeController : Controller
    {
        private readonly AppDbContext _context;

        public HomeController(AppDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            List<Slider> slider = _context.Sliders.ToList();
            return View(slider);
        }

    }
}
