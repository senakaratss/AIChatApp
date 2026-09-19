using AIChatApp.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AIChatApp.Application.Interfaces
{
    public interface IMessageRepository
    {
        Task<int> AddMessageAsync(Message message);
        Task<List<Message>> GetMessagesByConversationAsync(int conversationId,string userId);
    }
}
