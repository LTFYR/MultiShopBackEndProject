using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using MultiShopBackEndProject.DAL;
using MultiShopBackEndProject.Models;
using MultiShopBackEndProject.Utilities;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MultiShopBackEndProject.Areas.ShopAdmin.Controllers
{
    [Area("ShopAdmin")]
    public class CategoryController : Controller
    {
        private readonly AppDbContext _context;
        private readonly IWebHostEnvironment _env;

        public CategoryController(AppDbContext context, IWebHostEnvironment env)
        {
            _context = context;
            _env = env;
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
            category.Image = await category.Foto.FileCreator(_env.WebRootPath, "assets/img");
            _context.Categories.Add(category);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Edit(int? id)
        {
            if (id == 0 || id == null) return NotFound();
            Category category = _context.Categories.FirstOrDefault(c=>c.Id == id);
            if(category == null) return View();
            return View(category);
        }


        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public async Task<IActionResult> Edit(int? id, Category ncategory)
        {
            if (id == null || id == 0) return NotFound();
            Category current = _context.Categories.FirstOrDefault(c=>c.Id == id);
            if(ncategory == null) return NotFound();
            bool copy = _context.Categories.Any(c => c.Name.Trim().ToLower() == ncategory.Name.Trim().ToLower());
            if (copy)
            {
                ModelState.AddModelError("Name", "Eyni adi tekrar daxil etmeye calisdiniz");
                return View();
            }
            _context.Categories.Add(current);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if(id == 0 || id == null) return NotFound();
            Category category = await _context.Categories.FindAsync(id);
            if(category == null) return NotFound();
            _context.Categories.Remove(category);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Detail(int? id)
        {
            if (id == 0 || id == null) return NotFound();
            Category category = _context.Categories.FirstOrDefault(s => s.Id == id);
            return View(category);
        }
    }
}
