using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entity.Models.EntityModels.Adm
{
    /// <summary>
    /// 
    /// </summary>
    [Table("adm_encashment_infos")]
    public class AdmEncashmentInfo
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
        [Column("create_date")]
        public DateTime CreateDate { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [Column("amount")]
        public decimal Amount { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [Column("encashment_id")]
        public int EncashmentId { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [Column("encashment_date")]
        public DateTime EncashmentDate { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [Column("encash_data")]
        public string EncashData { get; set; }
    }
}