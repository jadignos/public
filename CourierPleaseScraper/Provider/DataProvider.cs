using CourierPleaseScraper.Class;
using CourierPleaseScraper.Model;
using CourierPleaseScraper.Properties;
using CourierPleaseScraper.Service;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CourierPleaseScraper.Provider
{
    public class DataProvider
    {
        private readonly Parser parser;
        private readonly string trackingNo;

        public DataProvider(string trackingNo)
        {
            this.trackingNo = trackingNo;
            string url = string.Format(Constants.URL, Settings.Default.KEY, trackingNo);
            parser = new Parser(new HttpScraper(url));
        }

        public async Task LoadAsync()
        {
            try
            {
                await parser.LoadAsync();
                Consignment = parser.GetConsignment();
                Coupons = parser.GetCoupons();
            }
            catch (Exception)
            {
                Consignment = new Consignment { ConsignmentNo = trackingNo };
                Coupons = new List<Coupon> { new Coupon { Detail = "Invalid request: no tracking found" } };
            }
        }

        public Consignment Consignment { get; private set; }
        public List<Coupon> Coupons { get; private set; }
    }
}
