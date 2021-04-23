using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using play_dachi.Models;
using Microsoft.AspNetCore.Http;

namespace play_dachi.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            int? fullness = HttpContext.Session.GetInt32("Fullness");
            if(fullness == null){
                HttpContext.Session.SetInt32("Fullness", 20);
                HttpContext.Session.SetInt32("Happiness", 20);
                HttpContext.Session.SetInt32("Energy", 50);
                HttpContext.Session.SetInt32("Meals", 3);
                HttpContext.Session.SetString("story", "");
                HttpContext.Session.SetInt32("win", 0);
            }
            int e_count = (int)HttpContext.Session.GetInt32("Energy");
            int f_count = (int)HttpContext.Session.GetInt32("Fullness");
            int h_count = (int)HttpContext.Session.GetInt32("Happiness");

            if(f_count >= 100 || h_count >= 100 || e_count >= 100){
                HttpContext.Session.SetInt32("win", 1);
                HttpContext.Session.SetString("story", "You Won!");
            }

            if(f_count <= 0 || h_count <= 0){
                HttpContext.Session.SetInt32("win", 2);
                HttpContext.Session.SetString("story", "You Lost, Next time");
            }

            ViewBag.Fullness = HttpContext.Session.GetInt32("Fullness");
            ViewBag.Happiness = HttpContext.Session.GetInt32("Happiness");
            ViewBag.Energy = HttpContext.Session.GetInt32("Energy");
            ViewBag.Meals = HttpContext.Session.GetInt32("Meals");
            ViewBag.story = HttpContext.Session.GetString("story");
            ViewBag.win = HttpContext.Session.GetInt32("win");
            return View();
        }

        public IActionResult Feed()
        {
            int count = (int)HttpContext.Session.GetInt32("Meals");
            Random rnd = new Random();
            if(count <= 0){
                HttpContext.Session.SetString("story", "You don't have any Meals");
            } else {
                int chance = rnd.Next(1, 4);
                if(chance == 1){
                    count--;
                    HttpContext.Session.SetInt32("Meals", count);
                    HttpContext.Session.SetString("story", $"You Feed, Meal -1, but didnt like it");
                    return RedirectToAction("Index");
                }
                count--;
                HttpContext.Session.SetInt32("Meals", count);
                int yum = (int)HttpContext.Session.GetInt32("Fullness");
                int example = rnd.Next(5, 10);
                yum += example;
                HttpContext.Session.SetInt32("Fullness", yum);
                HttpContext.Session.SetString("story", $"You feed your dachi +{example}, Meal -1");
            }
            return RedirectToAction("Index");
        }

        public IActionResult Play()
        {
            int e_count = (int)HttpContext.Session.GetInt32("Energy");
            Random rnd = new Random();
            if(e_count <= 0){
                HttpContext.Session.SetString("story", "No Energy to play");
            } else {
                int chance = rnd.Next(1, 4);
                if(chance == 1){
                    e_count -= 5;
                    HttpContext.Session.SetInt32("Energy", e_count);
                    HttpContext.Session.SetString("story", $"You play, Energy: -5, but didnt like it");
                    return RedirectToAction("Index");
                }
                e_count -= 5;
                HttpContext.Session.SetInt32("Energy", e_count);
                int example = rnd.Next(5, 10);
                int h_count = (int)HttpContext.Session.GetInt32("Happiness");
                h_count += example;
                HttpContext.Session.SetInt32("Happiness", h_count);
                HttpContext.Session.SetString("story", $"You play, Energy: -5, Happiness +{example}");
            }
            return RedirectToAction("Index");
        }

        public IActionResult Work()
        {
            int e_count = (int)HttpContext.Session.GetInt32("Energy");
            Random rnd = new Random();
            if(e_count <= 0){
                HttpContext.Session.SetString("story", "No Energy to play");
            } else {
                e_count -= 5;
                HttpContext.Session.SetInt32("Energy", e_count);
                int example = rnd.Next(1, 3);
                int m_count = (int)HttpContext.Session.GetInt32("Meals");
                m_count += example;
                HttpContext.Session.SetInt32("Meals", m_count);
                HttpContext.Session.SetString("story", $"You work, Energy: -5, Meal +{example}");
            }
            return RedirectToAction("Index");
        }

        public IActionResult Sleep()
        {
            int e_count = (int)HttpContext.Session.GetInt32("Energy");
            int f_count = (int)HttpContext.Session.GetInt32("Fullness");
            int h_count = (int)HttpContext.Session.GetInt32("Happiness");
            e_count += 15;
            f_count -= 5;
            h_count -= 5;
            HttpContext.Session.SetInt32("Energy", e_count);
            HttpContext.Session.SetInt32("Fullness", f_count);
            HttpContext.Session.SetInt32("Happiness", h_count);
            HttpContext.Session.SetString("story", $"You rest, Energy: +15, Fullness & Happiness: -5");
            return RedirectToAction("Index");
        }

        public IActionResult Restart()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Index");
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
