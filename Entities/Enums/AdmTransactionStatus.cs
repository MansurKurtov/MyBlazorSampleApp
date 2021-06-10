using System.ComponentModel;

namespace Entity.Enums
{
    /// <summary>
    /// 
    /// </summary>
    public enum AdmTransactionStatus
    {
        /// <summary>
        /// 
        /// </summary>
        [Description("Созданный")]
        Created = 0,

        /// <summary>
        /// 
        /// </summary>
        [Description("В ходе выполнения")]
        InProgress = 1,

        /// <summary>
        /// 
        /// </summary>
        [Description("Успешно завершено")]
        SuccessFinished = 2,

        /// <summary>
        /// 
        /// </summary>
        [Description("Завершено с ошибкой")]
        FinishedWithError = 3,

        /// <summary>
        /// 
        /// </summary>
        [Description("Отменино")]
        Canceled = 4,

        /// <summary>
        /// 
        /// </summary>
        [Description("Закрыто")]
        Closed = 5
    }
}
