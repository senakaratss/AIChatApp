using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AIChatApp.Application.Interfaces
{
    public interface IVoiceService
    {
        Task<string> SpeechToTextAsync(Stream audioStream, string fileName, string contentType);
        Task<byte[]> TextToSpeechAsync(string text);
    }
}
