using AIChatApp.Application.Features.Conversations.Queries;
using AIChatApp.Application.Features.Conversations.Results;
using AIChatApp.Application.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AIChatApp.Application.Features.Conversations.Handlers
{
    public class GetConversationsQueryHandler : IRequestHandler<GetConversationsQuery, List<GetConversationsQueryResult>>
    {
        private readonly IConversationRepository _conversationRepository;
        private readonly IIdentityService _identityService;

        public GetConversationsQueryHandler(IConversationRepository conversationRepository, IIdentityService identityService)
        {
            _conversationRepository = conversationRepository;
            _identityService = identityService;
        }

        public async Task<List<GetConversationsQueryResult>> Handle(GetConversationsQuery request, CancellationToken cancellationToken)
        {
            var currentUserId =await _identityService.GetCurrentUserIdAsync();

            var values = await _conversationRepository.GetAllConversationsAsync(currentUserId);

            return values.Select(x => new GetConversationsQueryResult
            {
                ConversationId = x.ConversationId,
                Title = x.Title,
                CreatedAt = x.CreatedAt,
                UpdatedAt = x.UpdatedAt
            }).ToList();
        }
    }
}
