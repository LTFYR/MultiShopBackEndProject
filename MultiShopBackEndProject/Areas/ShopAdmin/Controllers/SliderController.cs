using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MultiShopBackEndProject.DAL;
using MultiShopBackEndProject.Models;
using MultiShopBackEndProject.Utilities;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MultiShopBackEndProject.Areas.ShopAdmin.Controllers
{
    [Area("ShopAdmin")]
    public class SliderController : Controller
    {
        private readonly AppDbContext _context;
        private readonly IWebHostEnvironment _environment;

        public SliderController(AppDbContext context,IWebHostEnvironment environment)
        {
             _context = context;
            _environment = environment;
        }
        public IActionResult Index()
        {
            List<Slider> slider = _context.Sliders.ToList();
            return View(slider);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public async Task<IActionResult> Create(Slider slider)
        {
            if (!ModelState.IsValid) return View();
            slider.Image = await slider.Foto.FileCreator(_environment.WebRootPath, "assets/img");
            await _context.AddAsync(slider);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || id == 0) return NotFound();
            Slider slider = await _context.Sliders.FirstOrDefaultAsync(s => s.Id == id);
            if (slider == null) return NotFound();
            return View(slider);
        }


        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public async Task<IActionResult> Edit(int? id, Slider slider)
        {
            if (!ModelState.IsValid) return View();
            Slider existed = await _context.Sliders.FindAsync(id);
            if (existed == null) return NotFound();

            if (slider.Foto == null)
            {
                string fileName = existed.Image;
                _context.Entry(existed).CurrentValues.SetValues(slider);
                existed.Image = fileName;
            }
            else
            {
                if (!slider.Foto.ImageIsOk(3))
                {
                    ModelState.AddModelError("Photo", "You have chosen invalid size of image");
                    return View();
                }
                _context.Entry(existed).CurrentValues.SetValues(slider);
                Validator.Delete(_environment.WebRootPath, "assets/images/website-images", existed.Image);
                existed.Image = await slider.Foto.FileCreator(_environment.WebRootPath, "assets/images/website-images");

            }
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Delete(int id)
        {
            if (id == 0) return NotFound();
            Slider slider =await _context.Sliders.FindAsync(id);
            if(slider == null) return NotFound();
            _context.Sliders.Remove(slider);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));

        }

        public IActionResult Detail(int? id)
        {
            if (id == 0 || id == null) return NotFound();
            Slider slider = _context.Sliders.FirstOrDefault(s=>s.Id == id);
            return View(slider);
        }
    }
}
