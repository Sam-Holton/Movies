using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Movies.Data;
using Movies.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Movies.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly OMDbClient _oMDbClient;

        public HomeController(ILogger<HomeController> logger, OMDbClient oMDbClient)
        {
            _logger = logger;
            _oMDbClient = oMDbClient;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult SearchResult()
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
