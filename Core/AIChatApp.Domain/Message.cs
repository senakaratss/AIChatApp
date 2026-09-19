using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AIChatApp.Domain
{
    public class Message
    {
        public int MessageId { get; set; }
        public string Role { get; set; }
        public string Content { get; set; }
        public DateTime CreatedAt { get; set; }
        public int ConversationId { get; set; }
        public Conversation Conversation { get; set; }
    }
}
