using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entity.Models.EntityModels.Adm
{
    /// <summary>
    /// 
    /// </summary>
    [Table("nci_billing_services")]
    public class NciBillingService
    {
        /// <summary>
        /// 
        /// </summary>
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        [Column("id")]
        public int Id { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [Column("login")]
        public string Login { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [Column("password")]
        public string Password { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [Column("branch")]
        public string Branch { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [Column("url")]
        public string Url { get; set; }
    }
}
