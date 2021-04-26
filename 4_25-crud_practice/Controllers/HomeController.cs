using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using CRUD_Practice.Models;

namespace CRUD_Practice.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private CRUD_PracticeContext db;

        public HomeController(ILogger<HomeController> logger, CRUD_PracticeContext context)
        {
            _logger = logger;
            db = context;
        }

        public IActionResult Index()
        {
            List<Dish> allDish = db.Dishes.ToList();
            return View(allDish);
        }

        [HttpGet("/dish/new")]
        public IActionResult New()
        {
            return View();
        }

        [HttpPost("/dish/create")]
        public IActionResult Create(Dish newDish)
        {
            if(ModelState.IsValid == false)
            {
                return View("New");
            }
            db.Dishes.Add(newDish);
            db.SaveChanges();

            return RedirectToAction("Index");
        }

        [HttpGet("/dish/{dishId}")]
        public IActionResult Details(int dishId)
        {
            Dish this_dish = db.Dishes.FirstOrDefault(d => d.DishId == dishId);
            if(this_dish == null)
            {
                return RedirectToAction("Index");
            }
            return View(this_dish);
        }

        [HttpPost("/dish/{dishId}/delete")]
        public IActionResult Delete(int dishId)
        {
            Dish this_dish = db.Dishes.FirstOrDefault(d => d.DishId == dishId);
            if(this_dish == null)
            {
                return RedirectToAction("Index");
            }
            db.Dishes.Remove(this_dish);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet("/dish/{dishId}/edit")]
        public IActionResult Edit(int dishId)
        {
            Dish this_dish = db.Dishes.FirstOrDefault(d => d.DishId == dishId);
            if(this_dish == null){
                return RedirectToAction("Index");
            }
            return View(this_dish);
        }

        [HttpPost("/dish/{dishId}/update")]
        public IActionResult Update(Dish editedDish, int dishId)
        {
            if(ModelState.IsValid == false){
                Dish check_dish = db.Dishes.FirstOrDefault(d => d.DishId == dishId);
                return View("Edit", check_dish);
            }
            Dish this_dish = db.Dishes.FirstOrDefault(d => d.DishId == dishId);
            this_dish.ChefName = editedDish.ChefName;
            this_dish.DishName = editedDish.DishName;
            this_dish.Calories = editedDish.Calories;
            this_dish.Tastiness = editedDish.Tastiness;
            this_dish.Description = editedDish.Description;
            // this_dish.UpdatedAt = DateTime.Now;

            db.Dishes.Update(this_dish);
            db.SaveChanges();

            return RedirectToAction("Details", new { dishId = dishId});
        }
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
