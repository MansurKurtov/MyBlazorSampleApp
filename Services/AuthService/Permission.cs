using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuthService
{
    public static class Permission
    {
        /// <summary>
        ///  Справочниклар
        /// </summary>
        public const string ReferenceView = "1001";
        public const string ReferenceEdit = "1002";

        /// <summary>
        ///  Роллар
        /// </summary>
        public const string RoleView = "1101";
        public const string RoleEdit = "1102";

        /// <summary>
        ///  Фойдаланувчи
        /// </summary>
        public const string UserView = "1201";
        public const string UserEdit = "1202";

        /// <summary>
        ///  Ташкилот
        /// </summary>
        public const string CompanyView = "1301";
        public const string CompanyEdit = "1302";
        public const string CabinetView = "1303";
        public const string CabinetEdit = "1304";
       

    }
}
