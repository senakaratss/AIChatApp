using AIChatApp.Application.Features.Conversations.Results;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AIChatApp.Application.Features.Conversations.Queries
{
    public class GetConversationByIdQuery:IRequest<GetConversationByIdQueryResult>
    {
        public int ConversationId { get; set; }
    }
}
