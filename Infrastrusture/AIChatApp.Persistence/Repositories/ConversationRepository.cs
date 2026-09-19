using AIChatApp.Application.Interfaces;
using AIChatApp.Domain;
using AIChatApp.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AIChatApp.Persistence.Repositories
{
    public class ConversationRepository : IConversationRepository
    {
        private readonly AIChatContext _context;

        public ConversationRepository(AIChatContext context)
        {
            _context = context;
        }

        public async Task<int> AddConversationAsync(Conversation conversation)
        {
            await _context.Conversations.AddAsync(conversation);
            await _context.SaveChangesAsync();

            return conversation.ConversationId;
        }

        public async Task<List<Conversation>> GetAllConversationsAsync(string userId)
        {
            return await _context.Conversations.Where(x=>x.UserId==userId).OrderByDescending(x=>x.UpdatedAt).ToListAsync();
        }

        public async Task<Conversation> GetConversationByIdAsync(int conversationId)
        {
            return await _context.Conversations.FirstOrDefaultAsync(x => x.ConversationId == conversationId);
        }
    }
}
