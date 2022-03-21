using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using test.Data;
using test.Models;

namespace test.Controllers
{
    public class CategoryController : Controller
    {

        private readonly ApplicationDBContext _db;

        public CategoryController(ApplicationDBContext db)
        {
            _db = db;

        }
        public IActionResult Index()
        {
            IEnumerable<Category> objList = _db.Category;
            return View(objList);
        }

        //GET -CREATE
        public IActionResult Create()
        {
            return View();
        }

        //POST -CREATE
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Category obj)
        {
            if (ModelState.IsValid)
            {
                _db.Category.Add(obj);
                _db.SaveChanges();
                return RedirectToAction("Index");

            }
            else { return View(obj); }
        }

        public IActionResult Edit(int? Id)
        {
           if(Id ==null || Id == 0)
            { return NotFound(); }

            var obj = _db.Category.Find(Id);
            if(obj ==null)
            { return NotFound(); }
            return View(obj);
        }
    }
}
