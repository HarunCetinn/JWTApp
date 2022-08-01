using Microsoft.AspNetCore.Mvc;

namespace Udemy.JwtApp.Front.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
