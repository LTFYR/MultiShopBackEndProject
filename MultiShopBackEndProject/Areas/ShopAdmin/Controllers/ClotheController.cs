using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
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
    public class ClotheController : Controller
    {
        private readonly AppDbContext _context;
        private readonly IWebHostEnvironment _environment;

        public ClotheController(AppDbContext context,IWebHostEnvironment environment)
        {
            _context = context;
            _environment = environment;
        }
        public IActionResult Index()
        {
            List<Clothe> clothe = _context.Clothes.ToList();
            return View(clothe);
        }
        public IActionResult Create()
        {
            ViewBag.Category = _context.Categories.ToList();
            ViewBag.ClotheDescription = _context.ClotheDescriptions.ToList();
            ViewBag.ClotheInformation = _context.ClotheInformation.ToList();

            return View();
        }


        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public async Task<IActionResult> Create(Clothe clothe)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.Category = _context.Categories.ToList();
                ViewBag.ClotheDescription = _context.ClotheDescriptions.ToList();
                ViewBag.ClotheInformation = _context.ClotheInformation.ToList();
                return View();
            }
            if(clothe.Main == null || clothe.Photos == null)
            {
                ViewBag.Category = _context.Categories.ToList();
                ViewBag.ClotheDescription = _context.ClotheDescriptions.ToList();
                ViewBag.ClotheInformation = _context.ClotheInformation.ToList();
                ModelState.AddModelError(string.Empty, "Can not be empty");
            }
            if (!clothe.Main.ImageIsOk(3))
            {
                ViewBag.Category = _context.Categories.ToList();
                ViewBag.ClotheDescription = _context.ClotheDescriptions.ToList();
                ViewBag.ClotheInformation = _context.ClotheInformation.ToList();
                ModelState.AddModelError(string.Empty, "Invalid image format selected");
                return View();
            }
            clothe.ClotheImages = new List<ClotheImage>();
            TempData["Filename"] = "";
            List<IFormFile> remove = new List<IFormFile>();
            foreach (var item in clothe.Photos)
            {
                if (!item.ImageIsOk(3))
                {
                    remove.Add(item);
                    clothe.Photos.Remove(item);
                    TempData["Filename"] += item.FileName + ",";
                }
                ClotheImage another = new ClotheImage
                {
                    Image = await item.FileCreator(_environment.WebRootPath, "assets/img"),
                    IsMain = false,
                    Alt = item.Name,
                    Clothe = clothe
                };
                clothe.ClotheImages.Add(another);
            }
            ClotheImage clotheImage = new ClotheImage
            {
                Image = await clothe.Main.FileCreator(_environment.WebRootPath, "assets/img"),
                IsMain = true,
                Alt = clothe.Name,
                Clothe = clothe
            };
            clothe.ClotheImages.Add(clotheImage);

            //Clothe exsited = _context.Clothes.FirstOrDefault(c=>c.Id == clothe.Id);
            //if (exsited == null)
            //{
            //    ModelState.AddModelError("Name", "Diresme");
            //    return View();
            //}
             await _context.Clothes.AddAsync(clothe);
             await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}
