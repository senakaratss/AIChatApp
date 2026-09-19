using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AIChatApp.Application.Features.Messages.Commands
{
    public class SendMessageCommand:IRequest<int>
    {
        public int? ConversationId { get; set; }
        public string Content { get; set; }
    }
}
