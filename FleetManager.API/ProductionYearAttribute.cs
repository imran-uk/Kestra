using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FleetManager.API
{
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field | AttributeTargets.Parameter, AllowMultiple = false)]
    public class ProductionYearAttribute : ValidationAttribute
    {
        public bool AllowShortNotation { get; set; }

        public override bool IsValid(object value)
        {
            // logic here to decide if production year is valid
            // based on business rues.
            int productionYear;

            if(int.TryParse(value.ToString(), out productionYear))
            {
                var stringLength = productionYear.ToString().Length;

                if (AllowShortNotation)
                {
                    if (stringLength != 2)
                    {
                        return false;
                    }
                    else
                    {
                        var currentShortYear = DateTime.Now.Year.ToString("yy");
                        return true;

                        /*
                        if (productionYear > currentShortYear)
                        {
                            return false;
                        }         
                        else
                        {
                            return true;
                        }*/
                    }
                }

                int currentYear = DateTime.Now.Year;

                if (currentYear != productionYear)
                {
                    return false;
                }

                if (stringLength == 4)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }
    }
}
