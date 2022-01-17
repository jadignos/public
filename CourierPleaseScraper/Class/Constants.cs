using System.Collections.Generic;

namespace CourierPleaseScraper.Class
{
    public class Constants
    {
        public const string URL = @"https://edi.couriersplease.com.au/track.php?key={0}&track={1}";

        public class Header
        {
            public static readonly string[] CONSIGNMENT = {
                "Consignment #",
                "Date",
                "Delivery ETA",
                "POP Shop Drop-Off",
                "Details",
                "Remarks",
                "Dead Weight",
                "Volume",
                "Service",
                "Status",
                "Delivered at",
                "POD",
                "References",
                "Items/Coupons"
            };

            public static readonly string[] COUPON = {
                "Date",
                "Time",
                "Contractor",
                "ContId",
                "Detail"
            };
        }

        public class ReportTemplate
        {
            public const string Consignment = @"
            CONSIGNMENT
                Consignment #       {0}
                Date                {1}
                Delivery ETA        {2}
                POP Shop Drop-Off   {3}
                Details             {4}
                                    {5}
                Dead Weight         {6}
                Volume              {7}
                Service             {8}
                Status              {9}
                Delivered at        {10}
                POD                 {11}
                References          {12}
                Items/Coupons       {13}";

            public const string Coupon = @"
            COUPON {5}
                Date        {0}
                Time        {1}
                Contractor  {2}
                ContId      {3}
                Detail      {4}";
        }
    }
}
