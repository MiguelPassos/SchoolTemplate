using SchoolTemplate.Enuns;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolTemplate.UtilityServices
{
    public class Common
    {
        public static string ShowAlert(ETypeAlert type, string message)
        {
            string alertDiv = @"<div class=""alert {0}"" role=""alert"">
                                    <i class=""fa {1}""></i>" + message +
                                 "</div>";
            switch (type)
            {
                case ETypeAlert.Success:
                    alertDiv = string.Format(alertDiv, "alert-success", "fa-check-circle");
                    break;
                case ETypeAlert.Info:
                    alertDiv = string.Format(alertDiv, "alert-info", "fa-exclamation-circle");
                    break;
                case ETypeAlert.Warning:
                    alertDiv = string.Format(alertDiv, "alert-warnig", "fa-exclamation-triangle");
                    break;
                case ETypeAlert.Error:
                    alertDiv = string.Format(alertDiv, "alert-danger", "fa-times-circle");
                    break;
            }
            return alertDiv;
        }
    }
}
