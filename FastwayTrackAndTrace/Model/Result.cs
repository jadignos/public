using System.Collections.Generic;

namespace FastwayApiManager.Model
{
    public class Result
    {
        public string LabelNumber { get; set; } = string.Empty;
        public IList<Scan> Scans { get; set; } = new List<Scan>();
        public string Signature { get; set; } = string.Empty;
        public string DistributedTo { get; set; } = string.Empty;
        public string DistributedDate { get; set; } = string.Empty;
        public string Reference { get; set; } = string.Empty;
        public string OriginalLabelNumber { get; set; } = string.Empty;
        public string IsOnforward { get; set; } = string.Empty;
        public bool IsNZPostOnforward { get; set; } = false;
        public string OnforwardLabelNumber { get; set; } = string.Empty;
        public string CallingCard { get; set; } = string.Empty;
        public string CountryCode { get; set; } = string.Empty;
        public IList<string> CallingCardLabelNumbers { get; set; } = new List<string>();
        public bool HasDScan { get; set; } = false;
        public string LastScanDate { get; set; } = string.Empty;
        public bool WasScannedLast24Hours { get; set; } = false;
        public string AddressOnParcel { get; set; } = string.Empty;
    }

}
