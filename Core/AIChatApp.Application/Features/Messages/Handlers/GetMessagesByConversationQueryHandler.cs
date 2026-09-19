using AIChatApp.Application.Features.Messages.Queries;
using AIChatApp.Application.Features.Messages.Results;
using AIChatApp.Application.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AIChatApp.Application.Features.Messages.Handlers
{
    public class GetMessagesByConversationQueryHandler : IRequestHandler<GetMessagesByConversationQuery, List<GetMessagesByConversationQueryResult>>
    {
        private readonly IMessageRepository _messageRepository;
        private readonly IIdentityService _identityService;

        public GetMessagesByConversationQueryHandler(IMessageRepository messageRepository, IIdentityService identityService)
        {
            _messageRepository = messageRepository;
            _identityService = identityService;
        }

        public async Task<List<GetMessagesByConversationQueryResult>> Handle(GetMessagesByConversationQuery request, CancellationToken cancellationToken)
        {
            var currentUserId = await _identityService.GetCurrentUserIdAsync();

            var values = await _messageRepository.GetMessagesByConversationAsync(request.ConversationId,currentUserId);

            return values.Select(x => new GetMessagesByConversationQueryResult
            {
                MessageId = x.MessageId,
                Role = x.Role,
                Content = x.Content,
                CreatedAt = x.CreatedAt,
                ConversationId = x.ConversationId
            }).ToList();
        }
    }
}
