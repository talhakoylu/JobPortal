using System;
using System.Collections.Generic;
using System.Text;
using Core.Utilities.Interceptors;
using FluentValidation;

namespace Core.Aspects.Autofac
{
    public class ValidationAspect : MethodInterception
    {
        private Type _validatorType;

        public ValidationAspect(Type validatorType)
        {
            if (!typeof(IValidator).IsAssignableFrom(validatorType))
            {
                throw new System.Exception("This validator is not an acceptable form. Validator type must be IValidator type.");
            }
            _validatorType = validatorType;
        }
    }
}
