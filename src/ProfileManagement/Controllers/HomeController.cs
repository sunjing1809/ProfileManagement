using Microsoft.AspNetCore.Mvc;

namespace ProfileManagement.Controllers
{
    public class HomeController : Controller
    {
        //Default action for Home Controller
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View();
        }

        public IActionResult ErrorFound(string Id)
        {
            return View("Error404");
        }
    }
}

