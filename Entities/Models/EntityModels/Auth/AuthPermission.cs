using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;

namespace Entity.Models.EntityModels.Auth
{
    [Table("auth_permissions", Schema = "auth")]
    public class AuthPermission
    {
        /// <summary>
        /// Primary Key
        /// </summary>

        [Column("id")]
        public int Id { get; set; }
        /// <summary>
        /// Номи(изох)
        /// </summary>
        [Column("name")]
        [Required]
        public string Name { get; set; }
        /// <summary>
        /// Permission
        /// </summary>
        [Column("permission_name")]
        [Required]
        public string PermissionName { get; set; }
        /// <summary>
        /// Permisssion коди
        /// </summary>
        [Column("permission_code")]
        [Required]
        public string PermissionCode { get; set; }

        /// <summary>
        /// Display order
        /// </summary>
        [Column("display_order")]
        public int DisplayOrder { get; set; }
        /// <summary>
        /// "Permission га тегишли  UI element кодлар"
        /// </summary>
        [Column("related_uielement_codes")]
        public string RelatedUielementCodes { get; set; }

        /// <summary>
        /// "Permission га тегишли permission кодлар
        /// </summary>
        [Column("related_permission_codes")]
        public string RelatedPermissionCodes { get; set; }

        /// <summary>
        /// Комментарий
        /// </summary>
        [Column("comment")]
        public string Comment { get; set; }

        /// <summary>
        /// Модул коди
        /// </summary>
        [Column("module_id")]
        [ForeignKey("ModulModel")]
        public int ModuleId { get; set; }

        [IgnoreDataMember]
        public virtual AuthModule ModulModel { get; set; }



    }
}
