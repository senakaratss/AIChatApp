using AIChatApp.Application.Features.Messages.Commands;
using AIChatApp.Application.Interfaces;
using AIChatApp.Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AIChatApp.Application.Features.Messages.Handlers
{
    public class SendMessageCommandHandler : IRequestHandler<SendMessageCommand, int>
    {
        private readonly IMessageRepository _messageRepository;
        private readonly IConversationRepository _conversationRepository;
        private readonly IIdentityService _identityService;

        public SendMessageCommandHandler(IMessageRepository messageRepository, IConversationRepository conversationRepository, IIdentityService identityService)
        {
            _messageRepository = messageRepository;
            _conversationRepository = conversationRepository;
            _identityService = identityService;
        }

        public async Task<int> Handle(SendMessageCommand request, CancellationToken cancellationToken)
        {
            var userId = await _identityService.GetCurrentUserIdAsync();

            int conversationId;
            if (request.ConversationId == null)
            {
                var content = request.Content.Trim();
                var conversation = new Conversation
                {
                    Title = content.Length > 30 ? content.Substring(0, 30) + "..." : content,
                    CreatedAt = DateTime.UtcNow,
                    UpdatedAt = DateTime.UtcNow,
                    UserId = userId
                };
                conversationId = await _conversationRepository.AddConversationAsync(conversation);
            }
            else
            {
                conversationId = request.ConversationId.Value;
            }

            var message = new Message
            {
                ConversationId = conversationId,
                Content = request.Content,
                Role = "user",
                CreatedAt = DateTime.UtcNow
            };

            await _messageRepository.AddMessageAsync(message);
            return conversationId;
        }
    }
}
