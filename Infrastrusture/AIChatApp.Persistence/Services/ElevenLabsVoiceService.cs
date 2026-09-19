using AIChatApp.Application.Interfaces;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace AIChatApp.Persistence.Services
{
    public class ElevenLabsVoiceService : IVoiceService
    {
        private readonly IConfiguration _configuration;
        private readonly HttpClient _httpClient;

        public ElevenLabsVoiceService(IConfiguration configuration, HttpClient httpClient)
        {
            _configuration = configuration;
            _httpClient = httpClient;
        }

        public async Task<string> SpeechToTextAsync(Stream audioStream, string fileName, string contentType)
        {
            var apiKey = _configuration["ElevenLabsApiKey"];

            using var form = new MultipartFormDataContent();

            using var audioContent = new StreamContent(audioStream);
            audioContent.Headers.ContentType = new MediaTypeHeaderValue(contentType.Split(';')[0]);

            form.Add(audioContent, "file", fileName);
            form.Add(new StringContent("scribe_v2"), "model_id");

            using var request = new HttpRequestMessage(HttpMethod.Post, "https://api.elevenlabs.io/v1/speech-to-text");
            request.Headers.Add("xi-api-key", apiKey);
            request.Content = form;

            var response = await _httpClient.SendAsync(request);
            var responseBody = await response.Content.ReadAsStringAsync();

            Console.WriteLine($"ElevenLabs Status: {(int)response.StatusCode}");
            Console.WriteLine($"ElevenLabs Response: {responseBody}");
            response.EnsureSuccessStatusCode();

            var result = await response.Content.ReadFromJsonAsync<SpeechToTextResponse>();

            return result?.Text ?? "";
        }

        public async Task<byte[]> TextToSpeechAsync(string text)
        {
            var apiKey = _configuration["ElevenLabsApiKey"];
            var voiceId = _configuration["ElevenLabsVoiceId"];

            var requestBody = new { text = text, model_id = "eleven_multilingual_v2" };
            using var request = new HttpRequestMessage(HttpMethod.Post, $"https://api.elevenlabs.io/v1/text-to-speech/{voiceId}");
            request.Headers.Add("xi-api-key", apiKey);
            request.Content = JsonContent.Create(requestBody);

            var response = await _httpClient.SendAsync(request);
            var responseBody = await response.Content.ReadAsStringAsync();
            if (!response.IsSuccessStatusCode)
            {
                throw new Exception(
                    $"ElevenLabs TTS hatası: {response.StatusCode} - {responseBody}");
            }

            return await response.Content.ReadAsByteArrayAsync();
        }
    }
}
