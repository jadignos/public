using HtmlAgilityPack;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace CourierPleaseScraper.Class
{
    public class HtmlHandler
    {
        public async Task<string> GetContents(string url)
        {
            if (string.IsNullOrWhiteSpace(url))
                throw new ArgumentException("URL cannot be empty.");

            var client = new HttpClient();
            using (var response = await client.GetAsync(url))
            {
                using (var content = response.Content)
                {
                    var html = await content.ReadAsStringAsync();
                    if (html.ToLower().Contains("invalid request"))
                        throw new ArgumentException("Invalid Key! Re-run the program using the correct key.");
                    return HtmlEntity.DeEntitize(html);
                }
            }
        }
    }
}
