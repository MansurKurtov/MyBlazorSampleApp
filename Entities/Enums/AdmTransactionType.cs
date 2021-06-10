using System.ComponentModel;

namespace Entity.Enums
{
    public enum AdmTransactionType
    {
        /// <summary>
        /// 
        /// </summary>
        [Description("Неизвестный")]
        Unucknown = 0,

        /// <summary>
        /// 
        /// </summary>
        [Description("Инкассация")]
        Encashment,

        /// <summary>
        /// 
        /// </summary>
        
        [Description("Пополнение карты")]
        CardReplenishment
    }
}
