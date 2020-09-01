using System;
using Microsoft.AspNetCore.Mvc;

namespace StudentRegistration.Controllers
{
    public partial class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
