using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entity.Models.EntityModels.Auth
{
    [Table("auth_uielements", Schema = "auth")]
    public class AuthUIElement
    {
        /// <summary>
        /// Primary Key
        /// </summary>
        [Key]
        [Column("id")]
        public int Id { get; set; }

        /// <summary>
        /// Объектнинг қисқача коди
        /// </summary>
        [Column("element_code")]
        public string ElementCode { get; set; }

        /// <summary>
        /// Изоҳ
        /// </summary>
        [Column("comment")]
        public string Comment { get; set; }

    }
}
