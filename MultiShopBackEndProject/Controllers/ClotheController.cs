using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MultiShopBackEndProject.DAL;
using MultiShopBackEndProject.Models;
using System.Collections.Generic;
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
            Clothe clothe = await _context.Clothes.Include(c => c.ClotheImages).Include(c => c.ClotheInformation).Include(c => c.ClotheDescription).ThenInclude(c => c.Clothes).Include(c => c.Category).FirstOrDefaultAsync(c => c.Id == id);
            if(clothe == null) return View();
            return View();
        }

        public async Task<IActionResult> Partial()
        {
            List<Clothe> clothes = await _context.Clothes.Include(p => p.ClotheImages).ToListAsync();
            return PartialView("_ClothePartialView", clothes);
        }
    }
}
