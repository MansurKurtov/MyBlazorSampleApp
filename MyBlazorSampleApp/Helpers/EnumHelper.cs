using MyBlazorSampleApp.Helpers.Extensions;
using MyBlazorSampleApp.Helpers.Extensions.Models;
using Entity.Enums;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MyBlazorSampleApp.Helpers
{
    public static class EnumHelper
    {
        public static List<EnumItem> GetPaymentStatuses()
        {
            var result = Enum.GetValues(typeof(AdmTransactionStatus)).Cast<AdmTransactionStatus>().Select(s => new EnumItem() { Value = Convert.ToInt32(s), Name = s.GetDescription() }).ToList();
            return result;
        }

        public static List<EnumItem> GetProviders()
        {
            var result = Enum.GetValues(typeof(AdmTransactionType)).Cast<AdmTransactionType>().Select(s => new EnumItem() { Value = Convert.ToInt32(s), Name = s.GetDescription() }).ToList();
            return result;
        }
    }
}
