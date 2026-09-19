using AIChatApp.Application.Features.Messages.Commands;
using AIChatApp.Application.Features.Messages.Queries;
using AIChatApp.Application.Interfaces;
using AIChatApp.Domain;
using MediatR;
using Microsoft.AspNetCore.SignalR;

namespace AIChatApp.WebUI.Hubs
{
    public class ChatHub : Hub
    {
        private readonly IAiService _aiService;
        private readonly IMessageRepository _messageRepository;
        private readonly IMediator _mediator;

        public ChatHub(IAiService aiService, IMessageRepository messageRepository, IMediator mediator)
        {
            _aiService = aiService;
            _messageRepository = messageRepository;
            _mediator = mediator;
        }

        public async Task SendMessage(int? conversationId, string message)
        {
            var command = new SendMessageCommand { ConversationId = conversationId, Content = message };
            var currentConversationId = await _mediator.Send(command);

            await Clients.Caller.SendAsync("ReceiveMessage", currentConversationId, message, "user");

            var messages = await _mediator.Send(new GetMessagesByConversationQuery { ConversationId = currentConversationId });

            var fullAiResponse = "";
            await foreach(var chunk in _aiService.GetResponseStreamAsync(messages))
            {
                fullAiResponse += chunk;
                await Clients.Caller.SendAsync("ReceiveAiChunk", currentConversationId, chunk,"assistant");
            }
            await Clients.Caller.SendAsync("ReceiveAiCompleted", currentConversationId);

            var assistantMessage = new Message
            {
                ConversationId = currentConversationId,
                Content = fullAiResponse,
                Role = "assistant",
                CreatedAt = DateTime.UtcNow
            };
            await _messageRepository.AddMessageAsync(assistantMessage);
        }
    }
}
