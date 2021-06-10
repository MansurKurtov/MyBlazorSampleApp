using Entity.Enums;
using System;

namespace MyBlazorSampleApp.Pages.Reports.Models
{
    public class AdmTransactionModel
    {
        /// <summary>
        /// 
        /// </summary>
        public int RowNumber { get; set; }
        
        /// <summary>
        /// 
        /// </summary>        
        public long Id { get; set; }

        /// <summary>
        /// 
        /// </summary>        
        public DateTime CreateDate { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public long GroupId { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string GroupName { get; set; }

        /// <summary>
        /// 
        /// </summary>
        
        public long AdmId { get; set; }

        /// <summary>
        /// 
        /// </summary>
        
        public string AdmName{ get; set; }

        /// <summary>
        /// 
        /// </summary>
        
        public DateTime PerformDate { get; set; }

        /// <summary>
        ///
        /// </summary>
        
        public decimal Amount { get; set; }

        /// <summary>
        /// 
        /// </summary>
        
        public DateTime? UpdateDate { get; set; }

        /// <summary>
        /// 
        /// </summary>
        
        public string ClientInn { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string ProviderName { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string OperatorName { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string PayType { get; set; }

        /// <summary>
        /// 
        /// </summary>
        
        public int BillingOperationId { get; set; }

        /// <summary>
        /// 
        /// </summary>
        
        public string ClientAccountCode { get; set; }

        /// <summary>
        /// 
        /// </summary>
        
        public string PerformRequestData { get; set; }

        /// <summary>
        /// 
        /// </summary>
        
        public string PerformResponseData { get; set; }

        /// <summary>
        /// 
        /// </summary>
        
        public AdmTransactionStatus State { get; set; }
    }
}
