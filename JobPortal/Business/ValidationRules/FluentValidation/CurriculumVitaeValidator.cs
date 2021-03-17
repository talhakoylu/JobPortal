using System;
using System.Collections.Generic;
using System.Text;
using Entities.Concrete;
using FluentValidation;

namespace Business.ValidationRules.FluentValidation
{
    public class CurriculumVitaeValidator : AbstractValidator<CurriculumVitae>
    {
        public CurriculumVitaeValidator()
        {
            RuleFor(cv => cv.Name).NotEmpty();
        }
    }
}
