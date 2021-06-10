using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entity.Models.EntityModels.Adm
{
    /// <summary>
    /// 
    /// </summary>
    [Table("adm_activation_historys")]
    public class AdmActivationHistory
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
        [Column("login")]
        public string Login { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [Column("user_id")]
        public int? UserId { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [ForeignKey("UserId")]
        public virtual AdmUser User { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [Column("mac_address")]
        public string MacAdress { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [Column("hdd_serial")]
        public string HddSerial { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [Column("os_user_name")]
        public string OsUserName { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [Column("os_version")]
        public string OsVersion { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [Column("base_board_serial_number")]
        public string BaseBoardSerialNumber { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [Column("ip_address")]
        public string IpAddress { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [Column("given_activation_key")]
        public string GivenActivationKey { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [Column("activation_date")]
        public DateTime ActivationDate { get; set; }
    }
}