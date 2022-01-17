using FastwayTrackAndTrace.Model;

namespace FastwayApiManager.Model
{
    public class Scan
    {
        public string Type { get; set; } = string.Empty;
        public string Courier { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string Date { get; set; } = string.Empty;
        public string RealDateTime { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public string Franchise { get; set; } = string.Empty;
        public string Status { get; set; } = string.Empty;
        public string StatusDescription { get; set; } = string.Empty;
        public CompanyInfo CompanyInfo { get; set; }
        public string UploadDate { get; set; } = string.Empty;
        public string Signature { get; set; } = string.Empty;
        public ParcelConnectAgent ParcelConnectAgent { get; set; }
    }
}
