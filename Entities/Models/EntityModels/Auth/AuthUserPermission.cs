using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entity.Models.EntityModels.Auth
{
    [Table("auth_user_permissions", Schema = "auth")]
    public class AuthUserPermission
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
        [ForeignKey("UsersModel")]
        public int UserId { get; set; }

        public virtual AuthUser UsersModel { get; set; }


        /// <summary>
        /// Модул коди
        /// </summary>
        [Column("permission_id")]
        [ForeignKey("PermissionModel")]
        public int PermissionId { get; set; }

        public virtual AuthPermission PermissionModel { get; set; }
    }
}
