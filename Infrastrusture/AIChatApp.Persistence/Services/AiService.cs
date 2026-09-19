using AIChatApp.Application.Features.Messages.Results;
using AIChatApp.Application.Interfaces;
using Google.GenAI;
using Google.GenAI.Types;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AIChatApp.Persistence.Services
{
    public class AiService : IAiService
    {
        private readonly Client _client;

        public AiService(IConfiguration configuration)
        {
            var apiKey = configuration["GeminiApiKey"];
            _client = new Client(apiKey: apiKey);
        }

        public async Task<string> GetResponseAsync(string message)
        {
            var response = await _client.Models.GenerateContentAsync(
                model: "gemini-3.6-flash",
                contents: message
             );

            return response.Text;
        }

        public async IAsyncEnumerable<string> GetResponseStreamAsync(List<GetMessagesByConversationQueryResult> messages)
        {
            var contents = messages.Select(message => new Content
            {
                Role = message.Role == "user" ? "user" : "model",
                Parts = new List<Part>
                    {
                        new Part
                        {
                            Text = message.Content
                        }
                    }
            }).ToList();
            await foreach (var response in _client.Models.GenerateContentStreamAsync(model: "gemini-3.6-flash", contents: contents))
            {
                if (!string.IsNullOrEmpty(response.Text))
                {
                    yield return response.Text;
                }
            }
        }
    }
}
