using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MultiShopBackEndProject.DAL;
using MultiShopBackEndProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MultiShopBackEndProject.Controllers
{
    public class ShopController : Controller
    {
        private readonly AppDbContext _context;

        public ShopController(AppDbContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            List<Clothe> clothes = _context.Clothes.Include(c=>c.ClotheImages).ToList();
            return View(clothes);
        }

        public ActionResult SortName(string sorting)
        {
            List<Clothe> clothe = _context.Clothes.Include(c=>c.ClotheImages).OrderByDescending(c=>c.Id).ToList(); 
            switch (sorting)
            {
                case "desending":
                    clothe=clothe.OrderByDescending(clothe=>clothe.Name).ToList();
                    break;
                case "ascending":
                    clothe = clothe.OrderBy(clothe => clothe.Name).ToList();
                    break;
                default:
                    clothe = clothe.OrderByDescending(clothe => clothe.Id).ToList();
                    break;
            }
            return PartialView("_ShopPartialView",clothe);
        }
    }
}
