using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AIChatApp.Application.Features.Messages.Results
{
    public class GetMessagesByConversationQueryResult
    {
        public int MessageId { get; set; }
        public string Role { get; set; }
        public string Content { get; set; }
        public DateTime CreatedAt { get; set; }
        public int ConversationId { get; set; }
    }
}
