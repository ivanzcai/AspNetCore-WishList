﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WishList.Controllers
{

    public class ItemController : Controller
    {
        private readonly Data.ApplicationDbContext _context;

        // GET: /<controller>/
        public IActionResult Index()
        {
            var model = _context.Items.ToList();
            return View("Index", model);
        }

        public IActionResult Create(){
            return View("Create");
        }

        [HttpPost]
        public IActionResult Create(Models.Item item){
            _context.Items.Add(item);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id){
            var item = _context.Items.FirstOrDefault(e => e.Id == id);
            _context.Items.Remove(item);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
