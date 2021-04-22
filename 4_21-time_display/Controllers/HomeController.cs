using System;
using Microsoft.AspNetCore.Mvc;

namespace Time_Display
{
    public class HomeController : Controller
    {
        //localhost:5000
        [HttpGet("")]
        public ViewResult Index()
        {
            DateTime CurrentTime = DateTime.Now;
            ViewBag.Time = CurrentTime.ToString("MMM dd, yyyy hh:mm tt");
            return View();
        }
    }
}