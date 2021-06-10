using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entity.Models.EntityModels.Auth
{
    [Table("auth_structure_permissins", Schema = "auth")]
    public class AuthStructurePermission
    {
        /// <summary>
        /// Primary Key
        /// </summary>
        [Key]
        [Column("id")]
        public int Id { get; set; }
        ///// <summary>
        ///// Структура коди
        ///// </summary>
        //[Column("structure_id")]
        //[ForeignKey("RefStructureModel")]
        //[Required]
        //public int StructureId { get; set; }
        //[IgnoreDataMember]
        //public virtual RefStructure RefStructureModel { get; set; }
        /// <summary>
        /// Permission кодлар
        /// </summary>
        [Column("permission_codes")]
        [Required]
        public string PermissionCodes { get; set; }

        /// <summary>
        /// Permission кодлар
        /// </summary>
        [Column("uielement_codes")]
        [Required]
        public string UIelementCodes { get; set; }
    }
}
