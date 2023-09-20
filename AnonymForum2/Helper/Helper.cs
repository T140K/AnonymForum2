using System.Net.Http;

namespace AnonymForum2.Helper
{
    public class TopicAPI
    {
        public HttpClient Initial()
        {
            var Client = new HttpClient();

            Client.BaseAddress = new Uri("https://localhost:7226");
            return Client;
        }

    }
}
