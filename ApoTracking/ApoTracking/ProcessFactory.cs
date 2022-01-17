using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace ApoTracking
{
    public class ProcessFactory
    {
        private readonly Client _client;
        private readonly List<string> _labels;

        public Action<string> ReportStatus;
        public Action<int> ReportProgress;
        public Action<List<Result>> ReportResult;

        public ProcessFactory(Client client, List<string> labels)
        {
            _client = client;
            _labels = labels;
        }

        public async Task Process()
        {
            int startIndex = 1;
            int size = 10;
            var paginated = PaginatedList.Create(_labels, startIndex, size);

            while (paginated.HasNextPage)
            {
                string labels = string.Join(",", paginated);

                if (string.IsNullOrWhiteSpace(labels.Trim())) break;

                ReportStatus($"#{startIndex}: PROCESSING LABELS {Environment.NewLine}{labels}");

                var dynamicResult = await DownloadJson(labels);
                var trackingResult = DynamicResultData(dynamicResult);
                ReportResult(trackingResult);

                // Force delay to avoid - Error 429: Too Many Requests
                if (startIndex % 10 == 0)
                {
                    int seconds = 90;
                    ReportStatus($"TOO MANY REQUESTS. PLEASE WAIT FOR {seconds} SECONDS.");
                    await Task.Delay(TimeSpan.FromSeconds(seconds));
                }

                paginated = PaginatedList.Create(_labels, ++startIndex, size);
            }
        }

        private async Task<string> DownloadJson(string labels)
        {
            string credentials = $"{_client.UserName}:{_client.Password}";
            string authorization = Convert.ToBase64String(Encoding.Default.GetBytes(credentials));

            var request = (HttpWebRequest)WebRequest.Create($"{_client.Url}{labels}");
            request.Timeout = 10000;
            request.ReadWriteTimeout = 10000;
            request.Credentials = new NetworkCredential(_client.UserName, _client.Password);
            request.Headers["Authorization"] = "Basic " + authorization;
            request.Headers["account-number"] = _client.AccountNumber;

            try
            {
                var response = await request.GetResponseAsync();
                using (var responseStream = response.GetResponseStream())
                {
                    var reader = new StreamReader(responseStream, Encoding.UTF8);
                    var responseString = await reader.ReadToEndAsync();
                    response.Close();
                    return JsonConvert.DeserializeObject(responseString).ToString();
                }
            }
            catch (Exception) { return ""; }
        }

        private List<Result> DynamicResultData(string resultString)
        {
            var result = new List<Result>();
            dynamic resultRoot = JsonConvert.DeserializeObject<dynamic>(resultString);

            foreach (dynamic trackingResult in resultRoot.tracking_results)
            {
                string tracking_id = trackingResult.tracking_id;
                string status = trackingResult.status;

                if (trackingResult.trackable_items == null) continue;

                foreach (dynamic trackableItem in trackingResult.trackable_items)
                {
                    string article_id = trackableItem.article_id;
                    string product_type = trackableItem.product_type;

                    foreach (var evnt in trackableItem.events)
                    {
                        string location = evnt.location;
                        string description = evnt.description;
                        DateTime date = evnt.date;
                        result.Add(
                            new Result
                            {
                                tracking_id = tracking_id,
                                status = status,
                                article_id = article_id,
                                product_type = product_type,
                                location = location,
                                description = description,
                                date = date.ToShortDateString(),
                                time = date.ToShortTimeString()
                            });
                    }
                    result.Add(
                        new Result
                        {
                            tracking_id = tracking_id,
                            status = status,
                            article_id = article_id,
                            product_type = product_type
                        });
                }
                result.Add(
                   new Result
                   {
                       tracking_id = tracking_id,
                       status = status
                   });
            }
            return result;
        }
    }
}
