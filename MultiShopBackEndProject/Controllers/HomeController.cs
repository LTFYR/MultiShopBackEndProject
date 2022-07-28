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
                Clothes = _context.Clothes.Include(x=>x.ClotheImages).ToList(),
                Categories = _context.Categories.Include(c=>c.Clothes).ToList()
            };
            return View(homeVM);
        }


      [HttpPost]
      public IActionResult Index(string str)
        {

            
            HomeVM homeVM = new HomeVM
            {
                Sliders = _context.Sliders.ToList(),
                Categories = _context.Categories.Include(c => c.Clothes).ToList()
            };
            if (!string.IsNullOrWhiteSpace(str))
            {
                List<Clothe> clothes = _context.Clothes.Include(x=>x.ClotheImages).Where(x=>x.Name.Trim().ToLower().Contains(str)).ToList();
                homeVM.Clothes = clothes;
            }
            else
            {
            
            homeVM.Clothes = _context.Clothes.Include(x => x.ClotheImages).ToList();
            }
            return View(homeVM);
        }
        

        public async Task<IActionResult> Contact()
        {
            return View();
        }

    }
}
