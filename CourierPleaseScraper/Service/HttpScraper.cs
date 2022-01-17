using CourierPleaseScraper.Interface;
using HtmlAgilityPack;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace CourierPleaseScraper.Service
{
    public class HttpScraper : IScraper
    {
        private readonly HttpClient client;
        private readonly string url;

        public HttpScraper(string url) 
        {
            client = new HttpClient();
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
            this.url = url;
        }

        public Task<HtmlNode> GetDocumentAsync()
        {
            throw new System.NotImplementedException();
        }

        public async Task<string> GetStringAsync()
        {
            using (var response = await client.GetAsync(url))
            {
                using (var content = response.Content) 
                {
                    var htmlContent = await content.ReadAsStringAsync();
                    return htmlContent;
                }
            }
        }
    }
}
