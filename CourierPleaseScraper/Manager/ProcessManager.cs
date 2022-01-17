using CourierPleaseScraper.Class;
using CourierPleaseScraper.Model;
using CourierPleaseScraper.Provider;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CourierPleaseScraper.Manager
{
    public class ProcessManager
    {
        private readonly Dictionary<string, string> group;

        public ProcessManager() => group = Grouping.Create();

        public Action<int> UpdatePercentage;
        public Action<string> UpdateStatus;
        public Action<ConsignmentCouponReport> UpdateData;

        public List<string> TrackingNumbers { get; set; }

        public async Task RunAsync()
        {
            int index = 0;
            int count = TrackingNumbers.Count;

            foreach (var trackingNumber in TrackingNumbers)
            {
                index++;
                int percent = (int)Math.Round(((double)index / count) * 100.0);
                UpdatePercentage(percent);

                UpdateStatus($"{index} of {count}");
                UpdateStatus($"SCRAPE TRACKING # {trackingNumber}");

                var provider = new DataProvider(trackingNumber);
                await provider.LoadAsync();

                var consignmet = provider.Consignment;
                LogConsignment(consignmet);

                var coupons = provider.Coupons;
                LogCoupons(coupons);

                if (coupons.Count == 0) SendConsingmentData(consignmet);
                else SendCouponsData(consignmet, coupons);
            }
        }

        private void LogConsignment(Consignment consignment)
        {
            UpdateStatus(
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
                consignment.ItemsCoupons));
        }

        private void LogCoupons(List<Coupon> coupons)
        {
            int count = 1;
            coupons.ForEach(coupon =>
            {
                UpdateStatus(
                    string.Format(Constants.ReportTemplate.Coupon,
                    coupon.Date,
                    coupon.Time,
                    coupon.Contractor,
                    coupon.ContId,
                    coupon.Detail,
                    count++));
            });
        }

        private void SendConsingmentData(Consignment consignment)
        {
            UpdateData(new ConsignmentCouponReport
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
                Detail = "No scan events were found for this item",
                Grouping = "NO SCAN EVENTS"
            });
        }

        private void SendCouponsData(Consignment consignment, List<Coupon> coupons)
        {
            coupons.ForEach(coupon =>
            {
                UpdateData(new ConsignmentCouponReport
                {
                    // consignment
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
                    // coupon
                    CouponDate = coupon.Date,
                    Time = coupon.Time,
                    Contractor = coupon.Contractor,
                    ContId = coupon.ContId,
                    Detail = coupon.Detail,
                    Grouping = GetGroup(coupon.Detail)
                });
            });
        }

        private string GetGroup(string text)
        {
            foreach (var key in group.Keys)
            {
                if (text.ToLower().Contains(key.ToLower()))
                    return group[key];
            }
            return "";
        }
    }
}
