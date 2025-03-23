using System;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace AbstractNet
{
    public class AbstractClient
    {
        private static HttpClient httpClient = new HttpClient();
        private readonly JsonSerializerOptions options = new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true,
        };
        private string baseUrl = "https://images.abstractapi.com/v1/";
        public string ApiKey { get; set; }

        public AbstractClient(string apiKey)
        {
            ApiKey = apiKey;
            httpClient.DefaultRequestHeaders.Add("Accept", "application/json");
            httpClient.DefaultRequestHeaders.Add("User-Agent", "AbstractNet/1.0");
        }

        public async Task<AbstractResponse> ProcessImageFromUrl(AbstractRequest request)
        {
            if (string.IsNullOrWhiteSpace(request.ApiKey))
                throw new ArgumentException("An API key must be added to use this client.");

            if (string.IsNullOrWhiteSpace(request.Url))
                throw new ArgumentException("URL must not be empty or invalid.");


            HttpRequestMessage requestMessage = new HttpRequestMessage(HttpMethod.Post, baseUrl + "url/");
            requestMessage.Content = new StringContent(JsonSerializer.Serialize(request), Encoding.UTF8, "application/json");

            HttpResponseMessage response = await httpClient.SendAsync(requestMessage);

            if (!response.IsSuccessStatusCode)
                throw new HttpRequestException("There was an issue getting the image from the request provided.");

            string responseContent = await response.Content.ReadAsStringAsync();

            return JsonSerializer.Deserialize<AbstractResponse>(responseContent, options);
        }
    }
}
