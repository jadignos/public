namespace FastwayApiManager.Model
{
    public class TrackingLabelDto
    {
        public string LabelNumber { get; set; }

        public string Scan_Type { get; set; }
        public string Scan_Courier { get; set; }
        public string Scan_Description { get; set; }
        public string Scan_Date { get; set; }
        public string Scan_RealDateTime { get; set; }
        public string Scan_Name { get; set; }
        public string Scan_Franchise { get; set; }
        public string Scan_Status { get; set; }
        public string Scan_StatusDescription { get; set; }
        public string Scan_UploadDate { get; set; }
        public string Scan_Signature { get; set; }

        public string CompanyInfo_ContactName { get; set; }
        public string CompanyInfo_Company { get; set; }
        public string CompanyInfo_Address1 { get; set; }
        public string CompanyInfo_Address2 { get; set; }
        public string CompanyInfo_Address3 { get; set; }
        public string CompanyInfo_Address4 { get; set; }
        public string CompanyInfo_Address5 { get; set; }
        public string CompanyInfo_Address6 { get; set; }
        public string CompanyInfo_Address7 { get; set; }
        public string CompanyInfo_Address8 { get; set; }
        public string CompanyInfo_Comment { get; set; }

        public string ParcelConnectAgent_CourierNo { get; set; }
        public string ParcelConnectAgent_Address1 { get; set; }
        public string ParcelConnectAgent_Address2 { get; set; }
        public string ParcelConnectAgent_Identifier { get; set; }
        public string ParcelConnectAgent_Latitude { get; set; }
        public string ParcelConnectAgent_Longitude { get; set; }
        public string ParcelConnectAgent_Name { get; set; }
        public string ParcelConnectAgent_TradingHours { get; set; }
        public string ParcelConnectAgent_Postcode { get; set; }
        public string ParcelConnectAgent_Town { get; set; }

        public string Signature { get; set; }
        public string DistributedTo { get; set; }
        public string DistributedDate { get; set; }
        public string Reference { get; set; }
        public string OriginalLabelNumber { get; set; }
        public bool IsOnforward { get; set; }
        public bool IsNZPostOnforward { get; set; }
        public string OnforwardLabelNumber { get; set; }
        public string CallingCard { get; set; }
        public string CountryCode { get; set; }
        public bool HasDScan { get; set; }
        public string LastScanDate { get; set; }
        public bool WasScannedLast24Hours { get; set; }
        public string AddressOnParcel { get; set; }
    }
}
