using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AIChatApp.Domain
{
    public class Conversation
    {
        public int ConversationId { get; set; }
        public string UserId { get; set; }
        public string Title { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public List<Message> Messages { get; set; } = new List<Message>();
    }
}
