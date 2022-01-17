using CourierPleaseScraper.Properties;
using HtmlAgilityPack;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CourierPleaseScraper.Class
{
    public class Scraper
    {
        private readonly string _trackingNo;

        public Scraper(string trackingNo)
        {
            _trackingNo = trackingNo;
        }

        public Consignment Consignment { get; private set; }
        public List<Coupon> Coupons { get; private set; }

        public async Task ScrapeAsync()
        {
            var html = new HtmlHandler();
            var content = await html.GetContents(string.Format(Constants.URL, Settings.Default.KEY, _trackingNo));
            var doc = new HtmlDocument();
            doc.LoadHtml(content);

            var consignmentDoc = doc.GetElementbyId("consignmentdetails");
            var dictionary = SaveToDictionary(consignmentDoc);
            Consignment = ConvertToObject(dictionary);

            var couponDoc = doc.GetElementbyId("coupon");
            Coupons = GetCoupons(couponDoc);
        }

        private Dictionary<string, string> SaveToDictionary(HtmlNode nodes)
        {
            var consignments = new Dictionary<string, string>();
            var table = nodes.SelectSingleNode("table");
            var trList = table.SelectNodes("tr");

            foreach (var tr in trList)
            {
                string key = tr.SelectSingleNode("th").InnerText;
                string value = tr.SelectSingleNode("td").InnerText;

                if (string.IsNullOrWhiteSpace(key) &&
                    value.Contains("email tracking details")) break;

                if (string.IsNullOrWhiteSpace(key))
                    key = Constants.Consignment.Remarks;

                consignments.Add(key, value);
            }
            return consignments;
        }

        private Consignment ConvertToObject(Dictionary<string, string> dictionary)
        {
            var consignment = new Consignment
            {
                ConsignmentNo = dictionary.TryGetValue(Constants.Consignment.ConsignmentNo, out string value) ? value : string.Empty,
                Date = dictionary.TryGetValue(Constants.Consignment.Date, out value) ? value : string.Empty,
                DeliveryETA = dictionary.TryGetValue(Constants.Consignment.DeliveryETA, out value) ? value : string.Empty,
                POPShopDropOff = dictionary.TryGetValue(Constants.Consignment.POPShopDropOff, out value) ? value : string.Empty,
                Details = dictionary.TryGetValue(Constants.Consignment.Details, out value) ? value : string.Empty,
                Remarks = dictionary.TryGetValue(Constants.Consignment.Remarks, out value) ? value : string.Empty,
                DeadWeight = dictionary.TryGetValue(Constants.Consignment.DeadWeight, out value) ? value : string.Empty,
                Volume = dictionary.TryGetValue(Constants.Consignment.Volume, out value) ? value : string.Empty,
                Service = dictionary.TryGetValue(Constants.Consignment.Service, out value) ? value : string.Empty,
                Status = dictionary.TryGetValue(Constants.Consignment.Status, out value) ? value : string.Empty,
                DeliveredAt = dictionary.TryGetValue(Constants.Consignment.DeliveredAt, out value) ? value : string.Empty,
                POD = dictionary.TryGetValue(Constants.Consignment.POD, out value) ? value : string.Empty,
                References = dictionary.TryGetValue(Constants.Consignment.References, out value) ? value : string.Empty,
                ItemsCoupons = dictionary.TryGetValue(Constants.Consignment.ItemsCoupons, out value) ? value : string.Empty
            };
            return consignment;
        }

        private List<Coupon> GetCoupons(HtmlNode nodes)
        {
            var coupons = new List<Coupon>();
            var table = nodes.SelectSingleNode("table");
            var trList = table.SelectNodes("tr");

            foreach (var tr in trList)
            {
                var td = tr.SelectNodes("td");

                if (td == null) continue;
                if (td.Count == 1) continue;

                var coupon = new Coupon
                {
                    Date = td[0].InnerText,
                    Time = td[1].InnerText,
                    Contractor = td[2].InnerText,
                    ContId = td[3].InnerText,
                    Detail = td[4].InnerText
                };
                coupons.Add(coupon);
            }
            return coupons;
        }
    }
}
