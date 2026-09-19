using AIChatApp.Application.Features.Conversations.Queries;
using AIChatApp.Application.Features.Messages.Commands;
using AIChatApp.Application.Features.Messages.Queries;
using AIChatApp.Application.Features.Messages.Results;
using AIChatApp.Application.Interfaces;
using AIChatApp.Domain;
using AIChatApp.WebUI.Models;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Principal;
using System.Threading.Tasks;

namespace AIChatApp.WebUI.Controllers
{
    [Authorize]
    public class ChatController : Controller
    {
        private readonly IMediator _mediator;
        private readonly IIdentityService _identityService;
        private readonly IVoiceService _voiceService;

        public ChatController(IMediator mediator, IIdentityService identityService, IVoiceService voiceService)
        {
            _mediator = mediator;
            _identityService = identityService;
            _voiceService = voiceService;
        }

        public async Task<IActionResult> Index(int? id)
        {
            var user = await _identityService.GetCurrentUserAsync();

            var model = new ConversationViewModel
            {
                ConversationId = id,
                UserInitials = $"{user.Name[0]}{user.Surname[0]}",
                Messages = new List<GetMessagesByConversationQueryResult>()
            };
            if (id.HasValue)
            {
                var conversation = await _mediator.Send(new GetConversationByIdQuery { ConversationId = id.Value });
                var messages = await _mediator.Send(new GetMessagesByConversationQuery { ConversationId = id.Value });

                model.Title = conversation.Title;
                model.Messages = messages;
            }
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> SpeechToText(IFormFile audio)
        {
            if (audio == null || audio.Length == 0)
            {
                return BadRequest("Ses dosyası bulunamadı");
            }

            await using var stream = audio.OpenReadStream();
            var text = await _voiceService.SpeechToTextAsync(stream, audio.FileName, audio.ContentType);

            return Ok(new { text });
        }
        [HttpPost]
        public async Task<IActionResult> TextToSpeech([FromBody] string text)
        {
            if (string.IsNullOrWhiteSpace(text))
                return BadRequest();

            var audio = await _voiceService.TextToSpeechAsync(text);
            return File(audio, "audio/mpeg");
        }
    }
}
