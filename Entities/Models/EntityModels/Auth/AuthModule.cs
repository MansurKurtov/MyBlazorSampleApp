using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;

namespace Entity.Models.EntityModels.Auth
{
    [Table("auth_modules", Schema = "auth")]
    public class AuthModule
    {
        /// <summary>
        /// Primary Key
        /// </summary>
        [Key]
        [Column("id")]
        public int Id { get; set; }

        /// <summary>
        /// Модул номи
        /// </summary>
        [Column("name")]
        public string Name { get; set; }
        /// <summary>
        /// Изоҳ
        /// </summary>
        [Column("comment")]
        public string Comment { get; set; }
        /// <summary>
        /// Тегишли модул
        /// </summary>
        [Column("parent_id")]
        [ForeignKey("ParentModel")]
        public int? ParentId { get; set; }

        [IgnoreDataMember]
        public virtual AuthModule ParentModel { get; set; }
    }
}
