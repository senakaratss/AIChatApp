using AIChatApp.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AIChatApp.Application.Interfaces
{
    public interface IConversationRepository
    {
        Task<int> AddConversationAsync(Conversation conversation);
        Task<List<Conversation>> GetAllConversationsAsync(string userId);
        Task<Conversation> GetConversationByIdAsync(int conversationId);
    }
}
