using System;
using System.Collections.Generic;
using System.Text;
using Core.Entities.Concrete;
using FluentValidation;

namespace Business.ValidationRules.FluentValidation
{
    public class UserValidatior : AbstractValidator<User>
    {
        public UserValidatior()
        {
            RuleFor(u => u.FirstName).NotEmpty();
        }
    }
}
