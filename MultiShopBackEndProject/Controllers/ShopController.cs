﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MultiShopBackEndProject.DAL;
using MultiShopBackEndProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using X.PagedList;
using X.PagedList.Mvc.Core;

namespace MultiShopBackEndProject.Controllers
{
    public class ShopController : Controller
    {
        private readonly AppDbContext _context;

        public ShopController(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index(int? categoryId,string sorting,int page = 1)
        {
            ViewBag.CurrentPage = page;
            ViewBag.TotalPages = Math.Ceiling((decimal)_context.Clothes.Count() / 4);
            List<Clothe> clothes = new List<Clothe>();
            if (!string.IsNullOrEmpty(sorting))
            {     
               clothes = SortName(sorting);
            }
            else
            {
                if (categoryId == null)
                {
                   
                    clothes = _context.Clothes.Include(c => c.ClotheImages).Skip((page - 1) * 4).Take(4).ToList();
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
            List<Clothe> clothe = new List<Clothe>(); 
            switch (sorting)
            {
                case "desending":
                    clothe= _context.Clothes.Include(x => x.ClotheImages).OrderByDescending(clothe=>clothe.Name).ToList();
                    break;
                case "ascending":
                    clothe = _context.Clothes.Include(x => x.ClotheImages).OrderBy(clothe => clothe.Name).ToList();
                    break;
                case "price":
                    clothe = _context.Clothes.Include(x => x.ClotheImages).OrderByDescending(clothe => clothe.Price).ToList();
                    break;
                default:
                    clothe = _context.Clothes.Include(x => x.ClotheImages).ToList();
                    break;
            }
            return clothe;


            
        }
        
    }
}
