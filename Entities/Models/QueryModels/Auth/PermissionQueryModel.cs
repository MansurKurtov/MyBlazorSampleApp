using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Models.QueryModels.Auth
{
    public class PermissionQueryModel
    {
        public string permission_code { get; set; }
        public string related_uielement_codes { get; set; }
        public string related_permission_codes { get; set; }
    }
}
