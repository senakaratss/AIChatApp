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
    public class MessageRepository : IMessageRepository
    {
        private readonly AIChatContext _context;

        public MessageRepository(AIChatContext context)
        {
            _context = context;
        }

        public async Task<int> AddMessageAsync(Message message)
        {
            await _context.Messages.AddAsync(message);
            await _context.SaveChangesAsync();

            return message.MessageId;
        }

        public async Task<List<Message>> GetMessagesByConversationAsync(int conversationId,string userId)
        {
            return await _context.Messages.Where(x => x.ConversationId == conversationId && x.Conversation.UserId==userId)
                .OrderBy(x => x.CreatedAt).ToListAsync();
        }
    }
}
