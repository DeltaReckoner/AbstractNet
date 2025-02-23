using System;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace AbstractNet
{
    public class AbstractClient
    {
        private static HttpClient httpClient = new HttpClient()
        {
            BaseAddress = new Uri("https://images.abstractapi.com/v1/")
        };
        private JsonSerializerOptions serializerOptions = new JsonSerializerOptions();
        public string ApiKey { get; set; }

        public AbstractClient(string apiKey)
        {
            ApiKey = apiKey;
        }

        public async Task<AbstractResponse> ProcessImageFromUrl(AbstractRequest request)
        {
            if (string.IsNullOrWhiteSpace(ApiKey))
                throw new ArgumentException("An API key must be added to use this client.");

            if (string.IsNullOrWhiteSpace(request.Url) || !Uri.TryCreate(request.Url, UriKind.Absolute, out Uri uri))
                throw new ArgumentException("URL must not be empty or invalid.");

            StringContent requestContent = new StringContent(JsonSerializer.Serialize(request), Encoding.UTF8, "application/json");
            HttpResponseMessage response = await httpClient.PostAsync(request.Url, requestContent);

            if (!response.IsSuccessStatusCode)
                throw new HttpRequestException("There was an issue getting the image from the request provided.");

            string responseContent = await response.Content.ReadAsStringAsync();

            return (AbstractResponse) JsonSerializer.Deserialize(responseContent, typeof(AbstractResponse));
        }
    }
}
