using CsvHelper;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Text;

namespace CourierPleaseScraper.Service
{
    public class CsvWriter<T>
    {
        public CsvWriter(string path, IList<T> records)
        {
            using (var writer = new StreamWriter(path, false, Encoding.UTF8))
            {
                using (var csv = new CsvWriter(writer, CultureInfo.InvariantCulture))
                {
                    csv.WriteRecords(records);
                }
            }
        }
    }
}
