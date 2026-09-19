using AIChatApp.Application.Features.Conversations.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace AIChatApp.WebUI.ViewComponents
{
    public class _ConversationListComponentPartial : ViewComponent
    {
        private readonly IMediator _mediator;

        public _ConversationListComponentPartial(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var values = await _mediator.Send(new GetConversationsQuery());
            return View(values);
        }
    }
}
