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
        public async Task<IActionResult> Index(int? categoryId,string sorting)
        {
            List<Clothe> clothes;
            if (!string.IsNullOrEmpty(sorting))
            {
               clothes = SortName(sorting);
            }
            else
            {
                if (categoryId == null)
                {
                    clothes = _context.Clothes.Include(c => c.ClotheImages).ToList();
                }
                else
                {
                    clothes = await _context.Clothes
                    .Include(c => c.ClotheImages)
                    .Where(c => c.CategoryId == categoryId)
                    .OrderByDescending(c => c.Id)
                    .ToListAsync();
                }
            }

            return View(clothes);
        }

        public List<Clothe> SortName(string sorting)
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
            return clothe;


            
        }
        
    }
}
