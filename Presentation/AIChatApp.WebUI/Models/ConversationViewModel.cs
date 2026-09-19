using AIChatApp.Application.Features.Messages.Results;

namespace AIChatApp.WebUI.Models
{
    public class ConversationViewModel
    {
        public int? ConversationId { get; set; }
        public string Title { get; set; }
        public string UserInitials { get; set; }
        public List<GetMessagesByConversationQueryResult> Messages { get; set; }
    }
}
