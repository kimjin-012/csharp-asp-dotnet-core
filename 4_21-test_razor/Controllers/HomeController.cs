using System;
using Microsoft.AspNetCore.Mvc;

namespace TestProject
{
    public class HomeController : Controller
    {
        // Requests
        // localhost:5000/
        [HttpGet("")]
        public ViewResult Index()
        {
            // Visits Views/Home/
            // Looks for file Index.cshtml
            // If it can't find the file, it'll go look Views/Shared
            return View();
            // you could also provide a file name. return View("Index");
        }

        // this works too
        // [HttpGet("")]
        // public IActionResult SomeMethod()
        // {

        // }


        // localhost:5000/redirect
        [HttpGet("redirect")]
        public RedirectToActionResult Redirect()
        {
            return RedirectToAction("Tothis", new { Number = 9});
        }

        // localhost:5000/tothis
        [HttpGet("tothis/{Number}")]
        public ViewResult Tothis(int Number)
        {
            Console.WriteLine($"The number is {Number}");
            return View("Index");
        }

        // localhost:5000/projects
        [HttpGet("{project}")]
        public string Project(string project)
        {
            return $"This is my {project}, yoyoyo!";
        }

        // localhost:5000/users/??
        [HttpGet("users/{username}")]
        public string UserName(string username)
        {
            if(username == "Jin")
                return $"Whats up {username}! Sup Jinnifer!";
            return $"Whats up {username}";
        }
    }
}