using MyBlazorSampleApp.Pages.Reports.Models;
using IronPdf;
using OfficeOpenXml;
using OfficeOpenXml.Style;
using System;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.IO;
using System.Text;

namespace MyBlazorSampleApp.Helpers.PDF
{
    public static class PdfHelper
    {
        public static string GenerateHtml(AdmEncashmentModel model)
        {
            var sb = new StringBuilder();
            sb.Append("Инкассация<br/>");
            sb.Append("Банк:" + model.OwnerName + "<br/>");
            sb.Append("МФО:" + model.Mfo + "<br/>");
            sb.Append("Адм:" + model.AdmName + "<br/>");
            sb.Append("Дата операции:" + model.EncashmentDate.Date + "<br/>");
            sb.Append("Время операции:" + model.EncashmentDate.TimeOfDay + "<br/>");
            sb.Append("Сумма:" + model.Amount + "<br/>");
            sb.Append("Сдаль:_____________" + "<br/>");
            sb.Append("Приняль:_____________" + "<br/>");
            return sb.ToString();
        }
        public static byte[] toExcel(AdmEncashmentModel model)
        {
            ExcelPackage.LicenseContext = OfficeOpenXml.LicenseContext.Commercial;
            ExcelPackage.LicenseContext = OfficeOpenXml.LicenseContext.NonCommercial;
            ExcelPackage excel = new ExcelPackage();
            var ws = excel.Workbook.Worksheets.Add("Encashment_"+model.Id);
            ws.Cells["B3:C3"].Merge = true;
            ws.Cells["B3:C3"].Style.Font.Bold = true;
            ws.Cells["B3:C3"].Style.WrapText = true;
            ws.Cells["B3:C3"].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
            ws.Cells["B3:C3"].Value = "Инкассация";
            ws.Column(2).Width = 30;
            ws.Column(2).Style.Font.Bold = true;
            ws.Column(3).Width = 50;
            ws.Column(3).Style.HorizontalAlignment = ExcelHorizontalAlignment.Left;
            ws.Cells["B5"].Value = "Банк:";
            ws.Cells["C5"].Value = model.OwnerName;
            

           ws.Cells["B6"].Value = "МФО:";
            ws.Cells["C6"].Value = model.Mfo;

            ws.Cells["B7"].Value = "Адм:";
            ws.Cells["C7"].Value = model.AdmName;

            ws.Cells["B8"].Value = "Дата операции:";
            ws.Cells["C8"].Style.Numberformat.Format = "dd-mm-yyyy";
            ws.Cells["C8"].Value = model.EncashmentDate.ToShortDateString();

            ws.Cells["B9"].Value = "Время операции:";
            ws.Cells["C9"].Style.Numberformat.Format = "hh:ss";
            ws.Cells["C9"].Value = model.EncashmentDate.TimeOfDay;

            ws.Cells["B10"].Value = "Сумма:";
            ws.Cells["C10"].Value = model.Amount;

            ws.Cells["B11"].Value = "Сдаль:";
            ws.Cells["C11"].Value = "_____________";

            ws.Cells["B12"].Value = "Приняль:";
            ws.Cells["C12"].Value = "_____________";

            var stream = new MemoryStream();
            excel.SaveAs(stream);

            return stream.ToArray();
        }
        private static StreamReader streamToPrint;
        private static Font printFont;
        public static void Print(string Data)
        {
            try
            {
                byte[] byteArray = Encoding.UTF8.GetBytes(Data);
                MemoryStream stream = new MemoryStream(byteArray);
                streamToPrint = new StreamReader(stream);
                try
                {
                    printFont = new Font("Arial", 10);
                    PrintDocument pd = new PrintDocument();
                    pd.PrintPage += new PrintPageEventHandler
                       (pd_PrintPage);
                    pd.Print();
                }
                finally
                {
                    streamToPrint.Close();
                }
            }
            catch (Exception ex)
            {
            }
        }
        private static void pd_PrintPage(object sender, PrintPageEventArgs ev)
        {
            float linesPerPage = 0;
            float yPos = 0;
            int count = 0;
            float leftMargin = ev.MarginBounds.Left;
            float topMargin = ev.MarginBounds.Top;
            string line = null;

            // Calculate the number of lines per page.
            linesPerPage = ev.MarginBounds.Height /
               printFont.GetHeight(ev.Graphics);

            // Print each line of the file.
            while (count < linesPerPage &&
               ((line = streamToPrint.ReadLine()) != null))
            {
                yPos = topMargin + (count *
                   printFont.GetHeight(ev.Graphics));
                ev.Graphics.DrawString(line, printFont, Brushes.Black,
                   leftMargin, yPos, new StringFormat());
                count++;
            }

            // If more lines exist, print another page.
            if (line != null)
                ev.HasMorePages = true;
            else
                ev.HasMorePages = false;
        }

        public static byte[] GetPDF(string htmlSt)
        {
            var htmlToPdf = new HtmlToPdf();
            var pdf = htmlToPdf.RenderHtmlAsPdf(htmlSt);
            return pdf.Stream.ToArray();
        }

    }


}
