using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entity.Models.EntityModels.Adm
{
    [Table("adm_groups")]
    public class AdmGroup
    {
        /// <summary>
        /// 
        /// </summary>
        [Column("id")]
        public long Id { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [Column("name")]
        public string Name { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [Column("logo_url")]
        public string LogoUrl { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [Column("support_phone")]
        public string SupportPhone { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [Column("owner_id")]
        public long OwnerId { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [ForeignKey("OwnerId")]
        public virtual AdmOwner AdmOwner { get; set; }
    }
}
