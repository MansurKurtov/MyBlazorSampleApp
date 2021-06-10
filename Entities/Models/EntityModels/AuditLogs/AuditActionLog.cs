using Entity.Models.EntityModels.Auth;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entitys.Models.EntityModels.AuditLogs
{
    [Table("audit_action_log", Schema = "auditlog")]
    public class AuditActionLog 
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
        /// Амал бажарган вакт
        /// </summary>
        [Column("action_time")]
        public DateTime ActionTime { get; set; }

        /// <summary>
        /// Қилинган амал тури
        /// </summary>
        [Column("action_type")]
        public string ActionType { get; set; }
        /// <summary>
        /// Метод ёки сервис номи
        /// </summary>
        [Column("method_name")]
        public string MethodName { get; set; }

        /// <summary>
        /// Таблица номи
        /// </summary>
        [Column("table_name")]
        public string TableName { get; set; }


        /// <summary>
        /// Таблица ёзув коди
        /// </summary>
        [Column("record_id")]
        public int RecordId { get; set; }



        /// <summary>
        /// Янги маълумот (json)
        /// </summary>
        [Column("new_value")]
        public string NewValue { get; set; }

        /// <summary>
        /// Олдинги  маълумот (json)
        /// </summary>
        [Column("old_value")]
        public string OldValue { get; set; }

        /// <summary>
        /// "Parent ўчирилган ҳолатда ёзув ўчирилиши(cascade on delete)"
        /// </summary>
        [Column("del_parent_id")]
        public int? DelParentId { get; set; }


        /// <summary>
        /// Қўшимча маълумот
        /// </summary>
        [Column("add_info")]
        public string AddInfo { get; set; }


    }
}
