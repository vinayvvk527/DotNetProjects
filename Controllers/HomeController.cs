using EKart.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace EKart.Controllers
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
            return View();
        }
       

        public IActionResult Privacy()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(Login tbLogin)
        {
            List<UserRegistration> users= new List<UserRegistration>();
            using ElectronicsstoreContext electronicsstoreContext = new ElectronicsstoreContext();
            {
                users = electronicsstoreContext.UserRegistrations.ToList();
                foreach(UserRegistration user in users)
                {
                    if(user.UserName==tbLogin.UserName)
                    {
                        if (user.Password == tbLogin.Password)
                        {
                            HttpContext.Session.SetString("UserName", tbLogin.UserName.ToUpper());
                            return View("AdminHome");
                        }
                        
                    }
                }
            }
            ViewData["Message"] = "Incorrect UserName/Password";
            return View();
        }

        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return View("Index");
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}