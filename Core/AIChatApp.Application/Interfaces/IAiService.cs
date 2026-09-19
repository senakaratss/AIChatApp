using AIChatApp.Application.Features.Messages.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AIChatApp.Application.Interfaces
{
    public interface IAiService
    {
        Task<string> GetResponseAsync(string message);
        IAsyncEnumerable<string> GetResponseStreamAsync(List<GetMessagesByConversationQueryResult> messages);
    }
}
