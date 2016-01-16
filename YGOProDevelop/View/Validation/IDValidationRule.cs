using Microsoft.Practices.ServiceLocation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using YGOProDevelop.Service;
using System.Data.Entity.Validation;

namespace YGOProDevelop.View.Validation
{
    public class IDValidationRule:ValidationRule
    {
        private readonly ICDBService _cdbService = ServiceLocator.Current.GetInstance<ICDBService>();

        public override ValidationResult Validate(object value, System.Globalization.CultureInfo cultureInfo) {
            if(value!=null) {
                bool result =!_cdbService.IsIDExisted(Convert.ToInt64(value));
                return new ValidationResult(result,"卡密重复了！");
            }
            else {
                return new ValidationResult(false, "卡密重复了！");
            }
        }
    }
}
