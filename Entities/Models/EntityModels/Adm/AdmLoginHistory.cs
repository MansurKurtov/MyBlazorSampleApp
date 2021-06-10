using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entity.Models.EntityModels.Adm
{
    [Table("adm_login_historys")]
    public class AdmLoginHistory
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
        [Column("mac_adress")]
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
        [Column("app_version")]
        public string AppVersion { get; set; }

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
        [Column("given_security_token")]
        public string GivenSecurityToken { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [Column("login_date")]
        public DateTime LoginDate { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [Column("adm_cash_sum")]
        public decimal AdmCashSum { get; set; }
    }
}