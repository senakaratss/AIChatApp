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
    public class GetConversationByIdQueryHandler : IRequestHandler<GetConversationByIdQuery, GetConversationByIdQueryResult>
    {
        private readonly IConversationRepository _conversationRepository;

        public GetConversationByIdQueryHandler(IConversationRepository conversationRepository)
        {
            _conversationRepository = conversationRepository;
        }

        public async Task<GetConversationByIdQueryResult> Handle(GetConversationByIdQuery request, CancellationToken cancellationToken)
        {
            var value = await _conversationRepository.GetConversationByIdAsync(request.ConversationId);
            return new GetConversationByIdQueryResult
            {
                ConversationId = value.ConversationId,
                Title = value.Title,
                CreatedAt = value.CreatedAt,
                UpdatedAt = value.UpdatedAt
            };
        }
    }
}
