using AIChatApp.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace AIChatApp.WebUI.ViewComponents
{
    public class _UserProfileComponentPartial:ViewComponent
    {
        private readonly IIdentityService _identityService;

        public _UserProfileComponentPartial(IIdentityService identityService)
        {
            _identityService = identityService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var user = await _identityService.GetCurrentUserAsync();
            return View(user);
        }
    }
}
