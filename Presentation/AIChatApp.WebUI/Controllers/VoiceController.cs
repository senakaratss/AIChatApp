using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AIChatApp.WebUI.Controllers
{
    [Authorize]
    public class VoiceController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
