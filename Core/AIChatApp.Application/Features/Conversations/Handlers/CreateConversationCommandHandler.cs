using AIChatApp.Application.Features.Conversations.Commands;
using AIChatApp.Application.Interfaces;
using AIChatApp.Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AIChatApp.Application.Features.Conversations.Handlers
{
    public class CreateConversationCommandHandler : IRequestHandler<CreateConversationCommand, int>
    {
        private readonly IConversationRepository _conversationRepository;
        private readonly IIdentityService _identityService;

        public CreateConversationCommandHandler(IConversationRepository conversationRepository, IIdentityService identityService)
        {
            _conversationRepository = conversationRepository;
            _identityService = identityService;
        }

        public async Task<int> Handle(CreateConversationCommand request, CancellationToken cancellationToken)
        {
            var currentUserId = await _identityService.GetCurrentUserIdAsync();
            var conversation = new Conversation
            {
                Title = request.Title,
                UserId=currentUserId,
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow
            };

            return await _conversationRepository.AddConversationAsync(conversation);
        }
    }
}
