using System;

namespace MyBlazorSampleApp.Components.Models
{
    public class TransactionsSearch
    {
        public string PayDetail { get; set; }
        public string PayNumber { get; set; }
        public int ProviderId { get; set; }
        public int OperatorId { get; set; }
        public int AdmId { get; set; }
        public int PayStatusId { get; set; }
        public int UserId { get; set; }
        public DateTime BeginDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}
