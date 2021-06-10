using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entity.Models.EntityModels.Adm
{
    [Table("adm_owners")]
    public class AdmOwner : IIdentified
    {

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]        
        [Column("id")]
        public long Id { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [Column("name")]
        public string Name { get; set; }
    }
}
