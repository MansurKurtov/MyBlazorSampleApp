using System;

namespace MyBlazorSampleApp.Pages.Reports.Models
{
    public class AdmEncashmentModel
    {
        public int Id { get; set; }
        public int RowNumber { get; set; }
        public string OwnerName { get; set; }
        public string GroupName { get; set; }
        public string AdmName { get; set; }
        public string Mfo { get; set; }
        public long TerminalNumber { get; set; }
        public int EncashmentId { get; set; }
        public DateTime EncashmentDate { get; set; }
        public decimal Amount { get; set; }
    }
}
