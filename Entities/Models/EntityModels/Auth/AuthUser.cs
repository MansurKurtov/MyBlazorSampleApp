using Entity.Enums;
using Entitys.Models.EntityModels.Main;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;

namespace Entity.Models.EntityModels.Auth
{
    [Table("auth_users", Schema = "auth")]
    public class AuthUser
    {
        /// <summary>
        /// 
        /// </summary>
        [Column("id")]
        public int Id { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [Required]
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
        [Column("salt")]
        public string Salt { get; set; }

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
        [Column("role")]
        public AdmRole Role { get; set; }

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

        /// <summary>
        /// Ташкилот коди
        /// </summary>
        [Column("org_id")]
        [ForeignKey("OrgModel")]
        public int? OrgId { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [IgnoreDataMember]
        public virtual EntOrg OrgModel { get; set; }
    }
}
