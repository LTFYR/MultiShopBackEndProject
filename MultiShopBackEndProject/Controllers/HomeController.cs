using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MultiShopBackEndProject.DAL;
using MultiShopBackEndProject.Models;
using MultiShopBackEndProject.ViewModels;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
            HomeVM homeVM = new HomeVM
            {
                Sliders = _context.Sliders.ToList(),
                Clothes = _context.Clothes.ToList(),
                Categories = _context.Categories.Include(c=>c.Clothes).ToList()
            };
            return View(homeVM);
        }

        //[HttpGet]
        //public async Task<IActionResult> Index(string Search)
        //{
        //    ViewData["GetClothes"]  = Search;
        //    var clothequery = from x in _context.Clothes select x;
        //    if (!string.IsNullOrEmpty(Search))
        //    {
        //        clothequery = clothequery.Where(x=>x.Name.Contains(Search));
        //    }
        //    return View(await clothequery.AsNoTracking().ToListAsync());
        //}

    }
}
