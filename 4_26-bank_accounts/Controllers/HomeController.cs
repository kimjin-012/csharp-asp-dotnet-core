using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Bank_Accounts.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Bank_Accounts.Controllers
{
    public class HomeController : Controller
    {
        private Bank_AccountsContext db;
        public HomeController(Bank_AccountsContext context)
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
            return RedirectToAction("Success", new {userId = uid});
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
            return RedirectToAction("Success", new {userId = uid});
        }

        [HttpPost("/logout")]
        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Index");
        }

        [HttpGet("/account/{userId}")]
        public IActionResult Success(int userId)
        {
            if(isLoggedIn)
            {
                User getUser = db.Users.Include(t => t.Transactions).FirstOrDefault(u => u.UserId == userId);
                decimal CBalance = 0;
                if(getUser.Transactions != null)
                {
                foreach(Transaction action in getUser.Transactions)
                {
                    CBalance += action.Amount;
                }
                }
                ViewBag.Balance = CBalance;
                List<Transaction> newList = getUser.Transactions;
                newList = newList.OrderByDescending(t => t.CreatedAt.TimeOfDay).ToList();
                return View(newList);
            }
            return RedirectToAction("Index");
        }

        [HttpPost("/account/action")]
        public IActionResult Action(Transaction newAction)
        {
            if(ModelState.IsValid)
            {
                User getUser = db.Users.Include(t => t.Transactions).FirstOrDefault(u => u.UserId == uid);
                decimal CBalance = 0;
                foreach(Transaction action in getUser.Transactions)
                {
                    CBalance += action.Amount;
                }
                CBalance += newAction.Amount;
                if(CBalance < 0)
                {
                    ModelState.AddModelError("Amount", "Can't withdraw more than what you have...");
                }
            }

            if (ModelState.IsValid == false)
            {
                User getUser = db.Users.Include(t => t.Transactions).FirstOrDefault(u => u.UserId == uid);
                decimal BBalance = 0;
                foreach(Transaction action in getUser.Transactions)
                {
                    BBalance += action.Amount;
                }
                ViewBag.Balance = BBalance;
                return View("Success", getUser.Transactions.OrderByDescending(t => t.CreatedAt.TimeOfDay).ToList());
            }
            newAction.UserId = (int)uid;
            db.Transactions.Add(newAction);
            db.SaveChanges();
            return RedirectToAction("Success", new {userId = uid});
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
