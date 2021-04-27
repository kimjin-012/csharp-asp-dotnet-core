using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Wedding_Planner.Models;

namespace Wedding_Planner.Controllers
{
    public class HomeController : Controller
    {
        private Wedding_PlannerContext db;
        public HomeController(Wedding_PlannerContext context)
        {
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

        [HttpGet("")]
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
            return RedirectToAction("Dashboard");
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
            return RedirectToAction("Dashboard");
        }

        [HttpPost("/logout")]
        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Index");
        }

        [HttpGet("/Dashboard")]
        public IActionResult Dashboard()
        {
            if(isLoggedIn)
            {
                List<Wedding> expiredWeddings = db.Weddings
                .Where(w => w.Date < DateTime.Now)
                .ToList();

                db.RemoveRange(expiredWeddings);
                db.SaveChanges();

                List<Wedding> allWedding = db.Weddings.Include(w => w.Planner).Include(w => w.Assign).ThenInclude(e => e.User).ToList();
                return View(allWedding);
            }
            return RedirectToAction("Index");
        }

        [HttpGet("/add/wedding")]
        public IActionResult AddWedding()
        {
            if(isLoggedIn)
            {
                return View();
            }
            return RedirectToAction("Index");
        }

        [HttpPost("/create/wedding")]
        public IActionResult CreateWedding(Wedding newWedding)
        {   
            if(isLoggedIn)
            {
                if(ModelState.IsValid == false)
                {
                    return View("AddWedding");
                }
                newWedding.UserId = (int)uid;
                db.Weddings.Add(newWedding);
                db.SaveChanges();
                return RedirectToAction("Dashboard");
            }
            return RedirectToAction("Index");
        }

        [HttpPost("/delete/wedding/{weddingId}")]
        public IActionResult DeleteWed(int weddingId)
        {
            Wedding thisWed = db.Weddings.FirstOrDefault(w => w.WeddingId == weddingId);
            if(thisWed != null)
            {
                db.Weddings.Remove(thisWed);
                db.SaveChanges();
            }
            return RedirectToAction("Dashboard");
        }

        [HttpGet("/wedding/{weddingId}/edit")]
        public IActionResult Edit(int weddingId)
        {
            if(!isLoggedIn)
            {
                return RedirectToAction("Index");
            }
            Wedding thisWed = db.Weddings.FirstOrDefault(w => w.WeddingId == weddingId);
            if(thisWed == null || thisWed.UserId != uid)
            {
                return RedirectToAction("Dashboard");
            }
            return View(thisWed);
        }

        [HttpPost("/wedding/{weddingId}/update")]
        public IActionResult UpdateWedding(Wedding thisWed, int weddingId)
        {
            if(!isLoggedIn)
            {
                return RedirectToAction("Index");
            }
            if(ModelState.IsValid == false)
            {
                thisWed.WeddingId = weddingId;
                return View("Edit", thisWed);
            }
            Wedding editWed = db.Weddings.FirstOrDefault(w => w.WeddingId == weddingId);
            if(editWed == null)
            {
                return RedirectToAction("Dashboard");
            }
            editWed.UpdatedAt = DateTime.Now;
            editWed.WedderOne = thisWed.WedderOne;
            editWed.WedderTwo = thisWed.WedderTwo;
            editWed.Date = thisWed.Date;
            editWed.Address = thisWed.Address;

            db.Weddings.Update(editWed);
            db.SaveChanges();

            return RedirectToAction("Detail", new {weddingId = editWed.WeddingId});
        }

        [HttpPost("/wedding/{weddingId}/RSVP")]
        public IActionResult RSVP(int weddingId)
        {
            Event existEvent = db.Events.FirstOrDefault(e => e.UserId == (int)uid && e.WeddingId == weddingId);
            if(existEvent != null)
            {
                db.Events.Remove(existEvent);
            }
            else
            {
                Event newEvent = new Event()
                {
                    UserId = (int)uid,
                    WeddingId = weddingId
                };
                db.Events.Add(newEvent);
            }
            db.SaveChanges();
            return RedirectToAction("Dashboard");
        }

        [HttpGet("/wedding/{weddingId}/detail")]
        public IActionResult Detail(int weddingId)
        {
            Wedding thisWed = db.Weddings.Include(w => w.Assign).ThenInclude(e => e.User).FirstOrDefault(w => w.WeddingId == weddingId);
            return View(thisWed);
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
