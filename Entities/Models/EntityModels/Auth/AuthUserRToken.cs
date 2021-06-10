using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entity.Models.EntityModels.Auth
{
    [Table("auth_user_rtokens", Schema = "auth")]
    public class AuthUserRToken
    {
        /// <summary>
        /// Primary Key
        /// </summary>
        [Key]
        [Column("id")]
        public int Id { get; set; }

        /// <summary>
        /// Фойдаланувчи коди
        /// </summary>
        [Column("user_id")]
        [ForeignKey("UserModel")]
        public int UserId { get; set; }
        public virtual AuthUser UserModel { get; set; }

        /// <summary>
        /// Refresh token
        /// </summary>
        [Column("refresh_token")]
        public string RefreshToken { get; set; }
        /// <summary>
        /// Access token
        /// </summary>
        [Column("access_token")]
        public string AccessToken { get; set; }
        /// <summary>
        /// Клиент коди(броузер, мобил)
        /// </summary>
        [Column("client_id")]
        public string ClientId { get; set; }

        /// <summary>
        /// Яратилган сана
        /// </summary>
        [Column("created")]
        public DateTime Created { get; set; }
        /// <summary>
        /// Токен янгиланган вакт
        /// </summary>
        [Column("updated")]
        public DateTime Updated { get; set; }

    }
}
