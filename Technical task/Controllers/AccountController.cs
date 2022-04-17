using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using Technical_task.Models;

namespace Technical_task.Controllers
{
    public class AccountController : Controller
    {
        public List<UserModel> users = null;

        public AccountController()
        {
            users = new List<UserModel>();
            users.Add(new UserModel()
            {
                Id = 1,
                UserName = "backend",
                Password = "backend",
                Role = "backend"
            });
            users.Add(new UserModel()
            {
                Id = 2,
                UserName = "frontend",
                Password = "frontend",
                Role = "frontend"
            });
        }

        public IActionResult Login(string returnUrl="/")
        {
            LoginModel loginModel = new LoginModel();
            loginModel.ReturnUrl = returnUrl;
            return View(loginModel);
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginModel loginModel)
        {
            var user = users.Where(u => u.UserName == loginModel.UserName && u.Password == loginModel.Password).FirstOrDefault();
            if(user != null)
            {
                var claims = new List<Claim>()
                {
                    new Claim(ClaimTypes.NameIdentifier, Convert.ToString(user.Id)),
                    new Claim(ClaimTypes.Name, user.UserName),
                    new Claim(ClaimTypes.Role, user.Role)
                };

                var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                var principal = new ClaimsPrincipal(identity);
                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal,
                    new AuthenticationProperties()
                    {
                        IsPersistent = loginModel.RememberLogin
                    });
                return LocalRedirect(loginModel.ReturnUrl);
            }
            else
            {
                ViewBag.Message = "Invalid Credential";
                return View(loginModel);
            }
        }
        
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return LocalRedirect("/");
        }
    }
}
