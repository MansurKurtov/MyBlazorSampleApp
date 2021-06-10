using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Entity.Enums
{
    public enum EnumStructure
    {
        /// <summary>
        /// ФОНД
        /// </summary>
        [Description("ФОНД")]
        Fond = 1,

        /// <summary>
        /// Заведения (Арендодатель)
        /// </summary>
        [Description("Заведения (Арендодатель)")]
        Emitent = 2,  

        /// <summary>
        /// Организатор
        /// </summary>
        [Description("Организатор")]
        Organizator = 3,

        /// <summary>
        /// Агент
        /// </summary>
        [Description("Агент")]
        Agent = 4,

        /// <summary>
        /// Музей
        /// </summary>
        [Description("Музей")]
        Museum = 5,

        /// <summary>
        /// Театр
        /// </summary>
        [Description("Театр")]
        Theater = 6
    }
}
