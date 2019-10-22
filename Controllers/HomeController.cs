using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MyReceiptWebApp.Models;
using Newtonsoft.Json;

namespace MyReceiptWebApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public async Task<IActionResult> Index()
        {
            var urlRef = Request.Headers["Referer"].ToString();

            if (String.IsNullOrEmpty(urlRef)) 
            {
                return RedirectToAction("Index", "Login");
            }

            var receipts = new List<Account>();

            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync("https://myreceiptwebapi.azurewebsites.net/api/Users"))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    receipts = JsonConvert.DeserializeObject<List<Account>>(apiResponse);
                }
            }
            return View(receipts);
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
