using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Mvc;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Text.Json;
using Udemy.JwtApp.Front.Models;

namespace Udemy.JwtApp.Front.Controllers
{
    public class AccountController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public AccountController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public IActionResult SignIn()
        {
            return View();
        }
        
        [HttpPost]
        public async Task<IActionResult> SignIn(UserLoginModel model)
        {
            var client = _httpClientFactory.CreateClient();
            var requestContent = new StringContent(JsonSerializer.Serialize(model), Encoding.UTF8, "application/json");
            var response = await client.PostAsync("http://localhost:5177/api/Auth/SignIn", requestContent);
            if (response.IsSuccessStatusCode)
            {
                var jsonData = await response.Content.ReadAsStringAsync();
                var tokenModel= JsonSerializer.Deserialize<JwtResponseModel>(jsonData, new JsonSerializerOptions
                {
                    PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                });

                JwtSecurityTokenHandler handler = new JwtSecurityTokenHandler();
                var token = handler.ReadJwtToken(tokenModel?.Token);
                
                if(token != null)
                {
                    //var roles = token.Claims.Where(x => x.Type == ClaimTypes.Role).Select(x => x.Value);
                    //if (roles.Contains("Admin"))
                    //{

                    //}

                    ClaimsIdentity identity = new ClaimsIdentity(token.Claims,JwtBearerDefaults.AuthenticationScheme);

                    var authProops = new AuthenticationProperties
                    {
                        AllowRefresh = false,
                        ExpiresUtc = tokenModel.ExpireDate,
                        IsPersistent = true,
                    };

                    await HttpContext.SignInAsync(JwtBearerDefaults.AuthenticationScheme,new ClaimsPrincipal(identity),authProops);
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ModelState.AddModelError("", "kullanıcı adı veya şifre hatalı");

                    return View(model);
                }
                

                return RedirectToAction("Index"); //
            }
            else
            {
                ModelState.AddModelError("", "kullanıcı adı veya şifre hatalı");
                
                return View(model);
            }
            
        }
    }
}
