using Microsoft.Reporting.WebForms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PackageDelivery.GUI.Reportes
{
    public static class General
    {
        public static Tuple<byte[], string> RenderReports(string reportpath, List<string> dataset, List<object> data, string type, string deviceInfo = "")
        {
            LocalReport lr = new LocalReport();
            lr.ReportPath = reportpath;
            lr.EnableHyperlinks = true;

            Warning[] warnings;
            string[] streams;
            byte[] renderedBytes;
            string mimeType, encoding, fileNameExtension;

            for (int i = 0; i < dataset.Count; i++)
            {
                ReportDataSource res = new ReportDataSource(dataset[i], data[i]);
                lr.DataSources.Add(res);
            }

            renderedBytes = lr.Render(
                type,
                deviceInfo,
                out mimeType,
                out encoding,
                out fileNameExtension,
                out streams,
                out warnings
            );

            return new Tuple<byte[], string>(renderedBytes, mimeType);
        }
    }
}