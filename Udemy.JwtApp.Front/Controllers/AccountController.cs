using Microsoft.AspNetCore.Mvc;
using Udemy.JwtApp.Front.Models;

namespace Udemy.JwtApp.Front.Controllers
{
    public class AccountController : Controller
    {
        private readonly IHttpContextFactory _httpClientFactory;

        public AccountController(IHttpContextFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public IActionResult SignIn()
        {
            return View();
        }
        
        [HttpPost]
        public IActionResult SignIn(UserLoginModel model)
        {
            return View();
        }
    }
}
