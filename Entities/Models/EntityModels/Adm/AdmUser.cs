using Entity.Enums;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entity.Models.EntityModels.Adm
{
    /// <summary>
    /// 
    /// </summary>
    [Table("adm_users")]
    public class AdmUser
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
        [Column("login")]
        public string Login { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [Column("full_name")]
        public string FullName { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [Column("password")]
        public string Password { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [Column("create_date")]
        public DateTime CreateDate { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [Column("status")]
        public AdmUserStatus Status { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [Column("token")]
        public string Token { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [Column("refresh_token")]
        public string RefreshToken { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [Column("description")]
        public string Description { get; set; }
    }
}
