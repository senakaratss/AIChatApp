using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AIChatApp.Application.Features.Conversations.Commands
{
    public class CreateConversationCommand:IRequest<int>
    {
        public string Title { get; set; }
    }
}
