using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using nagp_devops_us.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace nagp_devops_us.Controllers
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
            return View(new ErrorViewModel
            {
                EnvVars = new List<KeyValuePair<string, string>>
                {
                    new KeyValuePair<string, string>("player_initial_lives",Environment.GetEnvironmentVariable("player_initial_lives")),
                    new KeyValuePair<string, string>("ui_properties_file_name", Environment.GetEnvironmentVariable("ui_properties_file_name")),
                    new KeyValuePair<string, string>("db_password", Environment.GetEnvironmentVariable("db_password")),
                    new KeyValuePair<string, string>("secret1", Environment.GetEnvironmentVariable("secret1"))
                }
            });
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

        public bool TestFunction(bool val)
        {
            //Added for coverage
            Console.WriteLine("coverage");
            return val;
        }
    }
}
