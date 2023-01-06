using BulkyBookWeb.Data;
using BulkyBookWeb.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BulkyBookWeb.Controllers
{
    public class CategoryController : Controller
    {

        private readonly ApplicationDbContext _db;

        public CategoryController(ApplicationDbContext db)
        {
            _db = db;
        }
        
        public IActionResult Index()
        {
            IEnumerable<Category> categories = _db.Categories.ToList();
            return View(categories);
        }

        //GET
        public IActionResult Create()
        {
          
            return View();
        }

        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Category obj)
        {

            if (ModelState.IsValid)
            {
                _db.Categories.Add(obj);
                _db.SaveChanges();
                TempData["success"] = "Category uspesno created";
                return RedirectToAction("Index");
            }
            return View(obj);
        }

        
       
        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var getCategoryFromDb = _db.Categories.Find(id);

            if (getCategoryFromDb == null)
            {
                return NotFound();  
            }

            return View(getCategoryFromDb);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Category obj)
        {

            if (ModelState.IsValid)
            {
                _db.Categories.Update(obj);
                _db.SaveChanges();
                TempData["success"] = "Category uspesno apdejtovana";
                return RedirectToAction("Index");
            }
            return View(obj);
        }

        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var getCategoryFromDb = _db.Categories.Find(id);

            if (getCategoryFromDb == null)
            {
                return NotFound();
            }

            return View(getCategoryFromDb);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(Category obj)
        {
                _db.Categories.Remove(obj);
                _db.SaveChanges();
            TempData["success"] = "Category uspesno obrisana";
            return RedirectToAction("Index");
        }
    }
}
