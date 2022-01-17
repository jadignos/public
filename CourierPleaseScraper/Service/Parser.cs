using CourierPleaseScraper.Class;
using CourierPleaseScraper.Interface;
using CourierPleaseScraper.Model;
using HtmlAgilityPack;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CourierPleaseScraper.Service
{
    public class Parser
    {
        private readonly IScraper scraper;
        private readonly HtmlDocument document;

        public Parser(IScraper scraper)
        {
            this.scraper = scraper;
            document = new HtmlDocument();
        }

        public async Task LoadAsync()
        {
            var content = await scraper.GetStringAsync();
            document.LoadHtml(HtmlEntity.DeEntitize(content));
        }

        private Dictionary<string, string> ParseConsignment()
        {
            var consignmentDoc = document.DocumentNode.SelectSingleNode("//*[@id='consignmentdetails']");
            if (consignmentDoc == null) 
                throw new System.Exception("Invalid request: no tracking found");

            var table = consignmentDoc.SelectSingleNode("table");
            var rows = table.SelectNodes("tr");
            rows.RemoveAt(rows.Count - 1); // remove last part bcoz it's a form
            var dict = rows.ToDictionary(
                key =>
                {
                    var text = key.SelectSingleNode("th").InnerText;
                    return string.IsNullOrWhiteSpace(text) ? "Remarks" : text;
                },
                value => value.SelectSingleNode("td").InnerText);
            return dict;
        }

        private List<Coupon> ParseCoupons()
        {
            var couponDoc = document.DocumentNode.SelectSingleNode("//*[@id='coupon']");
            var table = couponDoc.SelectSingleNode("table");
            var rows = table.SelectNodes("tr");
            var coupons = new List<Coupon>();

            foreach (var row in rows)
            {
                var td = row.SelectNodes("td");
                if (td == null) continue;
                if (td.Count == 1) continue;

                coupons.Add(new Coupon
                {
                    Date = td[0].InnerText,
                    Time = td[1].InnerText,
                    Contractor = td[2].InnerText,
                    ContId = td[3].InnerText,
                    Detail = td[4].InnerText
                });
            }

            return coupons;
        }

        private string GetDictionaryValue(string key, Dictionary<string, string> dictionary) => 
            dictionary.TryGetValue(key, out string value) ? value : "";

        public Consignment GetConsignment()
        {
            var headers = Constants.Header.CONSIGNMENT;
            var dictionary = ParseConsignment();
            return new Consignment
            {
                ConsignmentNo = GetDictionaryValue(headers[0], dictionary),
                Date = GetDictionaryValue(headers[1], dictionary),
                DeliveryETA = GetDictionaryValue(headers[2], dictionary),
                POPShopDropOff = GetDictionaryValue(headers[3], dictionary),
                Details = GetDictionaryValue(headers[4], dictionary),
                Remarks = GetDictionaryValue(headers[5], dictionary),
                DeadWeight = GetDictionaryValue(headers[6], dictionary),
                Volume = GetDictionaryValue(headers[7], dictionary),
                Service = GetDictionaryValue(headers[8], dictionary),
                Status = GetDictionaryValue(headers[9], dictionary),
                DeliveredAt = GetDictionaryValue(headers[10], dictionary),
                POD = GetDictionaryValue(headers[11], dictionary),
                References = GetDictionaryValue(headers[12], dictionary),
                ItemsCoupons = GetDictionaryValue(headers[13], dictionary),
            };
        }

        public List<Coupon> GetCoupons() => ParseCoupons();
    }
}
