using System.Collections.Generic;

namespace CourierPleaseScraper.Class
{
    public class Grouping
    {
        private static Dictionary<string, string> _dict;
        public static Dictionary<string, string> Create()
        {
            if (_dict == null)
            {
                _dict = new Dictionary<string, string>
                {
                    { "accepted", "ITEM ACCEPTED" },
                    { "loaded", "ITEM LOADED" },
                    { "delivered", "ITEM DELIVERED" },
                    { "picked up", "ITEM PICKED-UP" },
                    { "failed", "DELIVERY FAILED" },
                    { "linked", "LINKED ITEM" },
                    { "in transit", "IN TRANSIT" },
                    { "re-delivery", "RE-DELIVERY REQUESTED" },
                    // always above for specific grouping of 'Transfered'
                    { "refused", "REFUSED"},
                    { "return", "RETURN TO SENDER" },
                    { "damage", "DAMAGED"},
                    { "transferred", "TRANSFERED ITEM" },
                    // for errors
                    { "invalid request", "NO TRACKING FOUND"  }
                };
            }
            return _dict;
        }
    }
}
