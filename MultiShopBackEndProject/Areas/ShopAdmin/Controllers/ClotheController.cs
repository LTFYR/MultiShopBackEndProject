﻿using Microsoft.AspNetCore.Hosting;
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
            List<Clothe> clothe = _context.Clothes.Include(c=>c.ClotheImages).ToList();
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

        public async Task<IActionResult> Edit(int? id)
        {
            ViewBag.Info = _context.ClotheInformation.ToList();
            ViewBag.Desc = _context.ClotheDescriptions.ToList();
            ViewBag.Categories = _context.Categories.ToList();
            if (id == null || id == 0) return NotFound();
            Clothe clothe = await _context.Clothes.Include(p => p.ClotheImages).Include(p => p.ClotheInformation)
                .SingleOrDefaultAsync(p => p.Id == id);
            if (clothe == null) return NotFound();
            return View(clothe);
        }


        [HttpPost]
        [AutoValidateAntiforgeryToken]
        [ActionName("Edit")]
        public async Task<IActionResult> Update(int? id, Clothe clothe)
        {
            if (id == null || id == 0) return NotFound();
            Clothe current = await _context.Clothes.Include(p => p.ClotheImages).Include(p => p.ClotheInformation).Include(p => p.Category).SingleOrDefaultAsync(p => p.Id == id);
            if (current == null) return NotFound();
            List<ClotheImage> remove = current.ClotheImages.Where(p => p.IsMain == false && clothe.ImagesId.Contains(p.Id)).ToList();
            if (clothe == null) return NotFound();
            current.ClotheImages.RemoveAll(p => remove.Any(r => p.Id == r.Id));

            return RedirectToAction(nameof(Index));
        }

        public IActionResult Detail(int? id)
        {
            if (id == 0 || id == null) return NotFound();
            Clothe clothe = _context.Clothes.FirstOrDefault(s => s.Id == id);
            return View(clothe);
        }

        
    }
}
