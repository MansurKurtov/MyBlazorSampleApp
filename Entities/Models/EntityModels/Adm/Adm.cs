using Entity.Enums;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entity.Models.EntityModels.Adm
{
    /// <summary>
    /// 
    /// </summary>
    [Table("adms")]
    public class Adm
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
        [Column("adm_owner_id")]
        public long? AdmOwnerId { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [ForeignKey("AdmOwnerId")]
        public virtual AdmOwner AdmOwner { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [Column("adm_group_id")]
        public long? AdmGroupId { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [ForeignKey("AdmGroupId")]
        public virtual AdmGroup AdmGroup { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [Column("name")]
        public string Name { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [Column("display_name")]
        public string DisplayName { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [Column("mfo")]
        public string Mfo { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [Column("longitude")]
        public double? Longitude { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [Column("latitude")]
        public double? Latitude { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [Column("activation_key")]
        public string ActivationKey { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [Column("registration_date")]
        public DateTime? RegistrationDate { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [Column("security_token")]
        public string SecurityToken { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [Column("devices_status_update_date")]
        public DateTime? DevicesStatusUpdateDate { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [Column("logo_url")]
        public string LogoUrl { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [Column("support_phone")]
        public string SupportPhone { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [Column("last_access_date")]
        public DateTime? LastAccessDate { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [Column("last_payment_date")]
        public DateTime? LastPaymentDate { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [Column("application_version")]
        public string ApplicationVersion { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [Column("adm_model")]
        public string AdmModel { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [Column("address")]
        public string Address { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [Column("in_cash_sum")]
        public decimal? InCashSum { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [Column("adm_cash_sum")]
        public decimal? AdmCashSum { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [Column("in_cash_banknotes_count")]
        public long? InCashBanknotesCount { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [Column("cash_payment_sum")]
        public decimal? CashPaymentSum { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [Column("last_cash_payment_date")]
        public DateTime? LastCashPaymentDate { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [Column("last_encashment_date")]
        public DateTime? LastEncashmentDate { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [Column("application_id")]
        public long? ApplicationId { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [ForeignKey("ApplicationId")]
        public virtual AdmApplication Application { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [Column("serial_number")]
        public string AdmSerialNumber { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [Column("terminal_number")]
        public long? TerminalNumber { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [Column("status")]
        public AdmStatus? Status { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [Column("adm_data_version")]
        public int? AdmDataVersion { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [Column("is_open_day")]
        public bool? IsOpenDay { get; set; }
    }
}