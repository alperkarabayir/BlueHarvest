using FluentValidation;
using BlueHarvest.Api.Resources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlueHarvest.Api.Validators
{
    public class SaveTransactionResourceValidator : AbstractValidator<SaveTransactionResource>
    {
        public SaveTransactionResourceValidator()
        {
            RuleFor(x => x.Amount)
                .NotNull()
                .WithMessage("The Amount can not be null");
        }
    }
}
