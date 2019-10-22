using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MyReceiptWebApp.Models;
using MyReceiptWebApp.ViewModels;
using Newtonsoft.Json;

namespace MyReceiptWebApp.Controllers
{
    public class LoginController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        
        public async Task<IActionResult> Login(LoginViewModel model)
        {   
            if (ModelState.IsValid)
            {
              
                var accounts = new List<Account>();

                using (var httpClient = new HttpClient())
                {
                    using (var response = await httpClient.GetAsync("https://myreceiptwebapi.azurewebsites.net/api/Users"))
                    {
                        string apiResponse = await response.Content.ReadAsStringAsync();
                        accounts = JsonConvert.DeserializeObject<List<Account>>(apiResponse);
                    }
                }

                foreach (var acc in accounts)
                {
                    if (acc.Email.ToLower().Equals(model.Email.ToLower()) && acc.Password.Equals(model.Password))
                    {
                        return RedirectToAction("Index", "Home");
                    }
                }
                model.IsInvalid = true;
                //ModelState.AddModelError(string.Empty, "Username or password is invalid");
            }
            return View("Index", model);
        }
    }
}