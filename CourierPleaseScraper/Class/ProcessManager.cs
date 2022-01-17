using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace CourierPleaseScraper.Class
{
    public class ProcessManager
    {
        private readonly List<ConsignmentCouponViewModel> _data = new List<ConsignmentCouponViewModel>();
        public Action<string> ReportStatus;
        public Action<ConsignmentCouponViewModel> ReportToGrid;
        public List<string> TrackingNumbers { get; set; }

        public async Task Execute()
        {
            int startIndex = 1;
            int totalCount = TrackingNumbers.Count;

            foreach (var trackingNumber in TrackingNumbers)
            {
                if (string.IsNullOrWhiteSpace(trackingNumber)) continue;

                ReportStatus($"{startIndex}/{totalCount}");
                ReportStatus($"SCRAPING TRACKING # {trackingNumber}");

                var scraper = new Scraper(trackingNumber);
                await scraper.ScrapeAsync();

                ReportStatus(Status(scraper.Consignment));
                ReportStatus(Status(scraper.Coupons));

                ConstructAndSendViewModel(scraper.Consignment, scraper.Coupons);

                startIndex++;
            }
        }

        public void Export(string path) => new CsvMaker(path, _data);

        private string Status(Consignment consignment)
        {
            return
                string.Format(Constants.ReportTemplate.Consignment,
                consignment.ConsignmentNo,
                consignment.Date,
                consignment.DeliveryETA,
                consignment.POPShopDropOff,
                consignment.Details,
                consignment.Remarks,
                consignment.DeadWeight,
                consignment.Volume,
                consignment.Service,
                consignment.Status,
                consignment.DeliveredAt,
                consignment.POD,
                consignment.References,
                consignment.ItemsCoupons);
        }

        private string Status(List<Coupon> coupons)
        {
            var builder = new StringBuilder();
            int count = 1;
            coupons.ForEach(coupon =>
            {
                builder.AppendLine(
                    string.Format(Constants.ReportTemplate.Coupon,
                    coupon.Date,
                    coupon.Time,
                    coupon.Contractor,
                    coupon.ContId,
                    coupon.Detail,
                    count++));
            });
            return builder.ToString();
        }

        private void ConstructAndSendViewModel(Consignment consignment, List<Coupon> coupons)
        {
            var viewmodel = new ConsignmentCouponViewModel
            {
                ConsignmentNo = consignment.ConsignmentNo,
                Date = consignment.Date,
                DeliveryETA = consignment.DeliveryETA,
                POPShopDropOff = consignment.POPShopDropOff,
                Details = consignment.Details,
                Remarks = consignment.Remarks,
                DeadWeight = consignment.DeadWeight,
                Volume = consignment.Volume,
                Service = consignment.Service,
                Status = consignment.Status,
                DeliveredAt = consignment.DeliveredAt,
                POD = consignment.POD,
                References = consignment.References,
                ItemsCoupons = consignment.ItemsCoupons,
                CouponDate = "",
                Time = "",
                Contractor = "",
                ContId = "",
                Detail = ""
            };

            if(coupons.Count == 0)
            {
                ReportToGrid(viewmodel);
                _data.Add(viewmodel);
            }

            foreach (var coupon in coupons)
            {
                viewmodel.CouponDate = coupon.Date;
                viewmodel.Time = coupon.Time;
                viewmodel.Contractor = coupon.Contractor;
                viewmodel.ContId = coupon.ContId;
                viewmodel.Detail = coupon.Detail;

                ReportToGrid(viewmodel);
                _data.Add(viewmodel);
            }
        }
    }
}
