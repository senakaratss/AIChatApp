using AIChatApp.Application.Features.Messages.Results;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AIChatApp.Application.Features.Messages.Queries
{
    public class GetMessagesByConversationQuery:IRequest<List<GetMessagesByConversationQueryResult>>
    {
        public int ConversationId { get; set; }
    }
}
