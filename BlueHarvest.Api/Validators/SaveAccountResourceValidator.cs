using FluentValidation;
using BlueHarvest.Api.Resources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlueHarvest.Api.Validators
{
    public class SaveAccountResourceValidator : AbstractValidator<SaveAccountResource>
    {
        public SaveAccountResourceValidator()
        {
            RuleFor(x => x.Balance)
                .NotNull()
                .WithMessage("The Balance can not be null");
        }
    }
}
