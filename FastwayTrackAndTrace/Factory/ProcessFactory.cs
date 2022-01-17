using FastwayApiManager.Manager;
using FastwayApiManager.Model;
using FastwayTrackAndTrace.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace FastwayTrackAndTrace.Factory
{
    public class ProcessFactory
    {
        private readonly ClientManager _client;
        private readonly ExcelManager _excel;
        private readonly List<TrackingLabelDto> _dtos;

        public Action<string> ReportStatus;
        public Action<int> ReportProgress;

        public List<string> TrackingLabels { get; set; }

        public ProcessFactory(ClientManager client, ExcelManager excel)
        {
            _client = client;
            _excel = excel;
            _dtos = new List<TrackingLabelDto>();
        }

        public async Task Process()
        {
            int startIndex = 0;
            int count = TrackingLabels.Count;

            foreach (var label in TrackingLabels)
            {
                string trackingLabel = label.Trim();

                int progress = Convert.ToInt32((++startIndex / (double)count) * 100);
                ReportProgress(progress);

                if (string.IsNullOrWhiteSpace(trackingLabel))
                    continue;

                ReportStatus($"Processing : Label '{trackingLabel}'");

                _client.TrackingLabel = trackingLabel;
                string jsonResponse = await _client.Get();
                _client.Dispose();

                var response = JsonConvert.DeserializeObject<Response>(jsonResponse);
                if (response.Result == null)
                {
                    var responseError = JsonConvert.DeserializeObject<LabelError>(jsonResponse);
                    ReportStatus($" - Skipped [{responseError.Error}] {Environment.NewLine}");
                    continue;
                }

                _dtos.AddRange(ConvertToDto(response.Result));
                ReportStatus($" - Result [OK] {Environment.NewLine}");
            }

            _excel.GenerateExcelFromList(_dtos.ToList());

            _dtos.Clear();

            ReportStatus($"{Environment.NewLine}DONE ! {Environment.NewLine}File saved in {_excel.SavedFile}{Environment.NewLine}");
            ReportProgress(100);
        }

        private List<TrackingLabelDto> ConvertToDto(Result result)
        {
            var trackingLabels = new List<TrackingLabelDto>();
            foreach (var scan in result.Scans)
            {
                if (scan.ParcelConnectAgent == null)
                    scan.ParcelConnectAgent = new ParcelConnectAgent();

                trackingLabels.Add(
                    new TrackingLabelDto
                    {
                        LabelNumber = result.LabelNumber,

                        Scan_Type = scan.Type,
                        Scan_Courier = scan.Courier,
                        Scan_Description = scan.Description,
                        Scan_Date = scan.Date,
                        Scan_RealDateTime = scan.RealDateTime,
                        Scan_Name = scan.Name,
                        Scan_Franchise = scan.Franchise,
                        Scan_Status = scan.Status,
                        Scan_StatusDescription = scan.StatusDescription,
                        Scan_UploadDate = scan.UploadDate,
                        Scan_Signature = scan.Signature,

                        CompanyInfo_ContactName = Regex.Replace(scan.CompanyInfo.ContactName, @"[^\w\.@-]", ""),
                        CompanyInfo_Company = scan.CompanyInfo.Company,
                        CompanyInfo_Address1 = scan.CompanyInfo.Address1,
                        CompanyInfo_Address2 = scan.CompanyInfo.Address2,
                        CompanyInfo_Address3 = scan.CompanyInfo.Address3,
                        CompanyInfo_Address4 = scan.CompanyInfo.Address4,
                        CompanyInfo_Address5 = scan.CompanyInfo.Address5,
                        CompanyInfo_Address6 = scan.CompanyInfo.Address6,
                        CompanyInfo_Address7 = scan.CompanyInfo.Address7,
                        CompanyInfo_Address8 = scan.CompanyInfo.Address8,
                        CompanyInfo_Comment = scan.CompanyInfo.Comment,

                        ParcelConnectAgent_CourierNo = scan.ParcelConnectAgent.CourierNo,
                        ParcelConnectAgent_Address1 = scan.ParcelConnectAgent.Address1,
                        ParcelConnectAgent_Address2 = scan.ParcelConnectAgent.Address2,
                        ParcelConnectAgent_Identifier = scan.ParcelConnectAgent.Identifier,
                        ParcelConnectAgent_Latitude = scan.ParcelConnectAgent.Latitude,
                        ParcelConnectAgent_Longitude = scan.ParcelConnectAgent.Longitude,
                        ParcelConnectAgent_Name = scan.ParcelConnectAgent.Name,
                        ParcelConnectAgent_TradingHours = scan.ParcelConnectAgent.TradingHours,
                        ParcelConnectAgent_Postcode = scan.ParcelConnectAgent.Postcode,
                        ParcelConnectAgent_Town = scan.ParcelConnectAgent.Town,

                        Signature = result.Signature,
                        DistributedTo = result.DistributedTo,
                        DistributedDate = result.DistributedDate,
                        Reference = result.Reference,
                        OriginalLabelNumber = result.OriginalLabelNumber,
                        IsOnforward = result.IsOnforward.Trim() == "0",
                        IsNZPostOnforward = result.IsNZPostOnforward,
                        OnforwardLabelNumber = result.OnforwardLabelNumber,
                        CallingCard = result.CallingCard,
                        CountryCode = result.CountryCode,
                        HasDScan = result.HasDScan,
                        LastScanDate = result.LastScanDate,
                        WasScannedLast24Hours = result.WasScannedLast24Hours,
                        AddressOnParcel = result.AddressOnParcel
                    });
            }
            return trackingLabels;
        }
    }
}
