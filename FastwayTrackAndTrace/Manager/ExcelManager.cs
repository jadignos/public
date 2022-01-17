using Exportable.Engines;
using Exportable.Engines.Excel;
using System;
using System.Collections.Generic;
using System.IO;

namespace FastwayApiManager.Manager
{
    public class ExcelManager
    {
        public string SavedFile { get; private set; }
        public string BaseDirectory { get; set; }

        public void GenerateExcelFromList<TModel>(IEnumerable<TModel> dataModel) where TModel : class
        {
            if (!Directory.Exists(BaseDirectory))
                Directory.CreateDirectory(BaseDirectory);

            SavedFile = GenerateFilename();

            IExportEngine engine = new ExcelExportEngine();
            engine.AddData(dataModel);
            engine.Export(SavedFile);
        }

        private string GenerateFilename() =>
            Path.Combine(BaseDirectory, $"DaiReport-{DateTime.Now:yyyyMMddHHmmssfff}.xls");
    }
}
