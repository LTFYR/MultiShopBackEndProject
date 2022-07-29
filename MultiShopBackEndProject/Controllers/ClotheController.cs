using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MultiShopBackEndProject.ViewModels;
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
            Clothe clothe = await _context.Clothes.Include(c => c.ClotheImages)
                  .Include(x => x.ClotheInformation)
                  .Include(x => x.Category).ThenInclude(x=>x.Clothes).ThenInclude(x=>x.ClotheImages)
                  .Include(x => x.ClotheDescription)
                  .FirstOrDefaultAsync(x => x.Id == id);
            return View(clothe);
        }


        public async Task<IActionResult> Partial()
        {
            List<Clothe> clothes = await _context.Clothes.Include(p => p.ClotheImages).ToListAsync();
            return PartialView("_ClothePartialView", clothes);
        }

    }
}
