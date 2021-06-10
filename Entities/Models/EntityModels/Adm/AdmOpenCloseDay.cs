using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entity.Models.EntityModels.Adm
{
    /// <summary>
    /// 
    /// </summary>
    [Table("adm_open_close_day")]
    public class AdmOpenCloseDay
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
        [Column("operation_type")]
        public OpenCloseDay OperationType { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [Column("amount")]
        public decimal Amount { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [Column("response_data")]
        public string ResponseData { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [Column("request_data")]
        public string RequestData { get; set; }
    }
}
