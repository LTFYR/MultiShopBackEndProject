using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MultiShopBackEndProject.DAL;
using MultiShopBackEndProject.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MultiShopBackEndProject.Controllers
{
    public class ClotheController : Controller
    {
        private readonly AppDbContext _context;

        public ClotheController(AppDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult>  ClotheDetail(int? id)
        {

            //ClotheVM newcloth = new ClotheVM
            //{
            //    Clothe = _context.Clothes
            //      .Include(c => c.ClotheImages)
            //      .FirstOrDefault(c => c.Id == id),

            //    Clothes = new List<Clothe>(),
            //    Category = _context.Clothes.Include(c => c.Category).FirstOrDefault(c => c.Id == id).Category
            //};
            //List<Clothe> clothess = new List<Clothe>();
            //foreach (Clothe item in newcloth.Category.Clothes.ToList())
            //{
            //    clothess = _context.Clothes.Include(x => x.Category).ThenInclude(c => c.Clothes)
            //   .Where(p => item.CategoryId == p.CategoryId && p.Id != id).ToList();
            //    newcloth.Clothes.AddRange(clothess);
            //}
            //newcloth.Clothes = newcloth.Clothes.Distinct().ToList();
            //if (newcloth.Clothes == null) return View();
            //return View(newcloth);
            List<Clothe> clothe = await _context.Clothes
                .Include(c => c.ClotheImages)
                .Include(c => c.ClotheInformation)
                .Include(c => c.ClotheDescription)
                .ThenInclude(c => c.Clothes)
                .Include(c => c.Category)
                .Where(c => c.Id == id).ToListAsync();
            if(clothe == null) return View();
            return View(clothe);

        }


        public async Task<IActionResult> Partial()
        {
            List<Clothe> clothes = await _context.Clothes.Include(p => p.ClotheImages).ToListAsync();
            return PartialView("_ClothePartialView", clothes);
        }

    }
}
