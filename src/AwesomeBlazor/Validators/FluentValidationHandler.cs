using Blazorise;
using FluentValidation;
using System;
using System.Linq;
using System.Reflection;

namespace AwesomeBlazor.Validators
{
    public class FluentValidationHandler : IValidationHandler
    {
        public FluentValidationHandler()
        {

        }

        public void Validate(IValidation validation, object newValidationValue)
        {
            validation.NotifyValidationStarted();

            Type generic = typeof(AbstractValidator<>);
            Type validatorType = generic.MakeGenericType(newValidationValue.GetType());
            Type objectType = (from asm in AppDomain.CurrentDomain.GetAssemblies()
                               from type in asm.GetTypes()
                               where type.IsClass && type.BaseType == validatorType
                               select type).Single();

            var validator = Activator.CreateInstance(objectType);
            // Validate
            

            validation.NotifyValidationStatusChanged(ValidationStatus.None, new[] { "" });
        }
    }
}
