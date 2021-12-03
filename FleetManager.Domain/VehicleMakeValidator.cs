using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;
using FluentValidation;

namespace FleetManager.Domain
{
    public static class VehicleMakeValidator
    {
        public static IRuleBuilderOptions<T, string?> ValidVehicleMake<T>(this IRuleBuilder<T, string> ruleBuilder)
        {
            return ruleBuilder.NotNull().NotEmpty().Must(IsNotBmw)
              .WithMessage("Uh-uh sir, BMWs ain't allowed");
        }

        private static bool IsNotBmw(string make)
        {
            if (make == null)
            {
                return true;
            }

            make = make.Trim().ToLower();
            make = make.Replace(".", "");

            return !make.Equals("bmw");
        }
    }
}
