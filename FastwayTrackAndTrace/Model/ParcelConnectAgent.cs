using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FastwayTrackAndTrace.Model
{
    public class ParcelConnectAgent
    {
        public string CourierNo { get; set; } = string.Empty;
        public string Address1 { get; set; } = string.Empty;
        public string Address2 { get; set; } = string.Empty;
        public string Identifier { get; set; } = string.Empty;
        public string Latitude { get; set; } = string.Empty;
        public string Longitude { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public string TradingHours { get; set; } = string.Empty;
        public string Postcode { get; set; } = string.Empty;
        public string Town { get; set; } = string.Empty;
    }
}
