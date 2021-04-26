using CRUD_Practice.Models;
using Microsoft.AspNetCore.Mvc;

namespace CRUD_Practice.Controllers
{
    public class DishController : Controller
    {
        private CRUD_PracticeContext db;
        public DishController(CRUD_PracticeContext context)
        {
            db = context;
        }
    }
}