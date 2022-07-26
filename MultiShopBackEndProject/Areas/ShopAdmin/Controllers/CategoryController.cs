using Microsoft.AspNetCore.Mvc;
using MultiShopBackEndProject.DAL;
using MultiShopBackEndProject.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MultiShopBackEndProject.Areas.ShopAdmin.Controllers
{
    [Area("ShopAdmin")]
    public class CategoryController : Controller
    {
        private readonly AppDbContext _context;

        public CategoryController(AppDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            List<Category> category = _context.Categories.ToList();
            return View(category);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public async Task<IActionResult> Create(Category category)
        {
            if (category == null) return View();
            if (!ModelState.IsValid) return View();
            Category current = _context.Categories.FirstOrDefault(c=>c.Name.Trim().ToLower() == category.Name.Trim().ToLower());
            if (current != null) return View();
            _context.Categories.Add(category);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Edit(int? id)
        {
            if (id == 0 || id == null) return View();
            Category current = _context.Categories.FirstOrDefault(c=>c.Id == id);
            if(current == null) return View();
            return View(current);
        }


        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public async Task<IActionResult> Edit(int? id, Category category)
        {
            if (id == null || id == 0) return NotFound();
            Category current = _context.Categories.FirstOrDefault(c=>c.Id == id);
            if(category == null) return NotFound();
            bool copy = _context.Categories.Any(c => c.Name.Trim().ToLower() == category.Name.Trim().ToLower());
            if (copy)
            {
                ModelState.AddModelError("Name", "Eyni adi tekrar daxil etmeye calisdiniz");
                return View();
            }
            _context.Categories.Add(current);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}
