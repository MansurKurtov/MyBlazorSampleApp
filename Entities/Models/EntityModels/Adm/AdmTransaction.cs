using Entity.Enums;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entity.Models.EntityModels.Adm
{
    /// <summary>
    /// 
    /// </summary>
    [Table("adm_transaction")]
    public class AdmTransaction
    {
        /// <summary>
        /// 
        /// </summary>
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        [Column("id")]
        public int Id { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [Column("old_transaction_id")]
        public int? OldTransactionId { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [Column("create_date")]
        public DateTime CreateDate { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [Column("adm_id")]
        public int AdmId { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [ForeignKey("AdmId")]
        public virtual Adm Adm { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [Column("perform_date")]
        public DateTime PerformDate { get; set; }

        /// <summary>
        ///
        /// </summary>
        [Column("amount")]
        public decimal Amount { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [Column("update_date")]
        public DateTime? UpdateDate { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [Column("client_inn")]
        public string ClientInn { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [Column("billing_operation_id")]
        public int BillingOperationId { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [Column("client_account_code")]
        public string ClientAccountCode { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [Column("perform_request_data")]
        public string PerformRequestData { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [Column("perform_response_data")]
        public string PerformResponseData { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [Column("state")]
        public AdmTransactionStatus State { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [Column("transaction_type")]
        public AdmTransactionType TransactionType { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [Column("transaction_name")]
        public string TransactionName { get; set; }

    }
}
