using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Login_Register.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Http;

namespace Login_Register.Controllers
{
    public class HomeController : Controller
    {

        private readonly ILogger<HomeController> _logger;
        private Login_RegisterContext db;
        public HomeController(ILogger<HomeController> logger, Login_RegisterContext context)
        {
            _logger = logger;
            db = context;
        }
        private int? uid
        {
            get
            {
                return HttpContext.Session.GetInt32("UserId");
            }
        }

        private bool isLoggedIn
        {
            get
            {
                return uid != null;
            }
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost("/user/register")]
        public IActionResult Register(User newUser)
        {
            if(ModelState.IsValid)
            {
                bool existUser = db.Users.Any(u => u.Email == newUser.Email);
                if(existUser)
                {
                    ModelState.AddModelError("Email", "this Email is taken.");
                }
            }
            if(ModelState.IsValid == false)
            {
                return View("Index");
            }
            // Hasing the password
            PasswordHasher<User> hasher = new PasswordHasher<User>();
            newUser.Password = hasher.HashPassword(newUser, newUser.Password);

            db.Users.Add(newUser);
            db.SaveChanges();

            HttpContext.Session.SetInt32("UserId", newUser.UserId);
            HttpContext.Session.SetString("FirstName", newUser.FirstName);
            return RedirectToAction("Success");
        }

        [HttpPost("/login")]
        public IActionResult Login(Login loginUser)
        {
            string errMessage = "Invalid Email or Password";
            if(ModelState.IsValid == false)
            {
                return View("Index");
            }
            User getUser = db.Users.FirstOrDefault(u => u.Email == loginUser.LoginEmail);
            if(getUser == null)
            {
                ModelState.AddModelError("LoginEmail", errMessage);
                return View("Index");
            }
            PasswordHasher<Login> hasher = new PasswordHasher<Login>();
            PasswordVerificationResult passwordCompare = hasher.VerifyHashedPassword(loginUser, getUser.Password, loginUser.LoginPassword);
            if(passwordCompare == 0)
            {
                ModelState.AddModelError("LoginEmail", errMessage);
                return View("Index");
            }
            HttpContext.Session.SetInt32("UserId", getUser.UserId);
            HttpContext.Session.SetString("FirstName", getUser.FirstName);
            return RedirectToAction("Success");
        }

        [HttpPost("/logout")]
        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Index");
        }

        [HttpGet("/user/success")]
        public IActionResult Success()
        {
            if(isLoggedIn)
            {
                return View();
            }
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
