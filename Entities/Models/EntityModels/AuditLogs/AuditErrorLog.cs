using Entity.Models.EntityModels.Auth;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entitys.Models.EntityModels.AuditLogs
{
    [Table("audit_error_log", Schema = "auditlog")]
    public class AuditErrorLog 
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
        /// Маълумот киритилган вакт
        /// </summary>
        [Column("error_time")]
        public DateTime ErrorTime { get; set; }

        /// <summary>
        /// Метод ёки сервис номи
        /// </summary>
        [Column("method_name")]
        public string MethodName { get; set; }
        /// <summary>
        /// Error message  
        /// </summary>
        [Column("error_message")]
        public string ErrorMessage { get; set; }

        /// <summary>
        /// "Қўшилган, ўзгартирилган ёки    ўчирилган маълумот(json)"
        /// </summary>
        [Column("object_value")]
        public string ObjectValue { get; set; }


        /// <summary>
        /// Қилинган амал тури
        /// </summary>
        [Column("action_type")]
        public string ActionType { get; set; }


    }
}
