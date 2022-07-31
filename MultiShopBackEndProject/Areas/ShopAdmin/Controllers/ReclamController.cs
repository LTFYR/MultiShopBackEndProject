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
    public class ReclamController : Controller
    {
        private readonly AppDbContext _context;
        private readonly IWebHostEnvironment _env;

        public ReclamController(AppDbContext context,IWebHostEnvironment env)
        {
            _context = context;
            _env = env;
        }
        public IActionResult Index()
        {
            List<Reclam> reclam = _context.Reclams.ToList();
            return View(reclam);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public async Task<IActionResult> Create(Reclam reclam)
        {
            if (reclam == null) return View();
            if (!ModelState.IsValid) return View();
            Reclam current = _context.Reclams.FirstOrDefault(r=>r.Id == reclam.Id);
            if (current != null) return View();
            reclam.Image = await reclam.Foto.FileCreator(_env.WebRootPath, "assets/img");
            _context.Reclams.Add(reclam);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        public IActionResult Edit(int? id)
        {
            if (id == 0 || id == null) return NotFound();
            Reclam reclam = _context.Reclams.FirstOrDefault(c => c.Id == id);
            if (reclam == null) return View();
            return View(reclam);
        }

        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public async Task<IActionResult> Edit(int? id, Reclam reclam)
        {
            if (id == null || id == 0) return NotFound();
            Reclam current = _context.Reclams.FirstOrDefault(c => c.Id == id);
            if (reclam == null) return NotFound();
            bool copy = _context.Categories.Any(c => c.Name.Trim().ToLower() == reclam.Title.Trim().ToLower());
            if (copy)
            {
                ModelState.AddModelError("Name", "Wrong click");
                return View();
            }
            _context.Reclams.Add(current);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }






        public async Task<IActionResult> Delete(int? id)
        {
            if (id == 0 || id == null) return NotFound();
            Reclam reclam = await _context.Reclams.FindAsync(id);
            if (reclam == null) return NotFound();
            _context.Reclams.Remove(reclam);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Detail(int? id)
        {
            if (id == 0 || id == null) return NotFound();
            Reclam reclam = _context.Reclams.FirstOrDefault(s => s.Id == id);
            return View(reclam);
        }
    }
}
