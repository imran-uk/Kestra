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

            // TODO this does not quite do what i want when given null...
            // should say "Make should not be null"
            // example of custom validator predicate
            RuleFor(v => v.Make).ValidVehicleMake();
        }
    }
}
