using System;
using System.Collections.Generic;
using System.Text;
using Core.Entities.Concrete;
using FluentValidation;

namespace Business.ValidationRules.FluentValidation
{
    public class UserOperationClaimValidator : AbstractValidator<UserOperationClaim>
    {
        public UserOperationClaimValidator()
        {
            RuleFor(uoc => uoc.OperationClaimId).NotEmpty();
            RuleFor(uoc => uoc.UserId).NotEmpty();
        }
    }
}
