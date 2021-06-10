using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entity.Models.EntityModels.Adm
{
    /// <summary>
    /// 
    /// </summary>
    [Table("adm_application")]
    public class AdmApplication
    {
        /// <summary>
        /// 
        /// </summary>
        [Column("id")]
        public long Id { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [Column("version")]
        public string Version { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [Column("decription")]
        public string Decription { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [Column("application_file")]
        public string ApplicationFile { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [Column("is_actual")]
        public bool IsActual { get; set; }
    }
}
