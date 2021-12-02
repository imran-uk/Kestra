using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using FluentValidation;

namespace FleetManager.Domain
{
    public class VehicleValidator : AbstractValidator<VehicleModel>
    {
        public VehicleValidator()
        {
            RuleFor(v => v.Id).NotNull().NotEmpty();
            RuleFor(v => v.Model).NotNull().NotEmpty().Must(m => m.Length >= 2);
            RuleFor(v => v.Make).NotNull().NotEmpty().Must(IsNotBmw).WithMessage("We do not allow BMW - we just do not like them.");
            //RuleFor(v => v.Make).NotNull().NotEmpty().Must(m => !m.Equals("BMW"));
        }

        // TODO 
        // add some custom validators here
        
        // eg. Model must be at least two chars - done above

        // make must not be BMW - we don't like those
        // can be done using Must() predicate but I want a custom error message
        // I want the predicate to be NotBMW and to look for any
        // spellings B.M.W. and bmw and BMW etc

        private static bool IsNotBmw(string make)
        {
            make = make.Trim().ToLower();
            make = make.Replace(".", "");

            return !make.Equals("bmw");
        }
    }
}
