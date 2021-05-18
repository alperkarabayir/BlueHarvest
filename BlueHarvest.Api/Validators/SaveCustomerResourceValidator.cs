using FluentValidation;
using BlueHarvest.Api.Resources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlueHarvest.Api.Validators
{
    public class SaveCustomerResourceValidator : AbstractValidator<SaveCustomerResource>
    {
        public SaveCustomerResourceValidator()
        {
            RuleFor(x => x.Name)
                .NotNull()
                .NotEmpty()
                .WithMessage("The name can not be null or empty");

            RuleFor(x => x.Surname)
                .NotNull()
                .NotEmpty()
                .WithMessage("The surname can not be null or empty");
        }
    }
}
