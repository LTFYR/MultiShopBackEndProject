﻿using MultiShopBackEndProject.DAL;
using MultiShopBackEndProject.Models;
using System.Collections.Generic;
using System.Linq;

namespace MultiShopBackEndProject.Service
{
    public class LayoutService
    {
        private readonly AppDbContext _context;

        public LayoutService(AppDbContext context)
        {
            _context = context;
        }

        public List<Setting> Settings()
        {
            List<Setting> settings = _context.Settings.ToList();
            return settings;
        }

        public List<Category> Categories()
        {
            List<Category> categories = _context.Categories.ToList();
            return categories;
        }
    }
}
