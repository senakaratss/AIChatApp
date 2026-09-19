using AIChatApp.Application.Dtos;
using AIChatApp.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace AIChatApp.WebUI.Controllers
{
    public class AuthController : Controller
    {
        private readonly IIdentityService _identityService;

        public AuthController(IIdentityService identityService)
        {
            _identityService = identityService;
        }
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Register(RegisterDto dto)
        {
            try
            {
                await _identityService.RegisterAsync(dto);
                return RedirectToAction("Login");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("",ex.Message);
                return View(dto);
            }
        }
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Login(LoginDto dto)
        {
            var result = await _identityService.LoginAsync(dto);
            if (!result)
            {
                ModelState.AddModelError("", "Invalid email or password.");
                return View(dto);
            }
            return RedirectToAction("Index","Chat");
        }
    }
}
