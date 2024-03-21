using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Tribute_MVC.Models;
using Tribute_MVC.Services;

namespace Tribute_MVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private IAdminService _admin = null;
        public HomeController(IAdminService adminService, ILogger<HomeController> logger)
        {
            _admin = adminService;
            _logger = logger;
        }

        public IActionResult Index()
        {
            try
            {
                List<Tribute> tributes = _admin.GetTributes();
                return View(tributes);
            }
            catch (Exception ex)
            {
                return RedirectToAction("Error", "Home", new { message = ex.Message });
            }
        }
        public IActionResult About()
        {
            return View();
        }

        
        public IActionResult Error(string message)
        {
            ViewBag.Error = message;
            HttpContext.Session.Clear();
            return View();
        }
    }
}
