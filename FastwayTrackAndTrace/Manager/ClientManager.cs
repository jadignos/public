using System;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace FastwayApiManager.Manager
{
    public class ClientManager : BaseClient
    {      
        public string BaseUrl { get; set; }
        public string InvocationUrl { get; set; }
        public string ApiKey { get; set; }
        public int CountryCode { get; set; }
        public string TrackingLabel { get; set; }

        public async Task<string> Get()
        {
            Client.BaseAddress = new Uri(BaseUrl);
            Client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));

            var result = await Client.GetAsync(
                $"/{InvocationUrl}/{TrackingLabel}/{CountryCode}?api_key={ApiKey}");

            result.EnsureSuccessStatusCode();

            return await result.Content.ReadAsStringAsync();
        }
    }
}
