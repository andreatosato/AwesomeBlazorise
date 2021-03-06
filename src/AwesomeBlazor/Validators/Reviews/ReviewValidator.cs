using AwesomeBlazor.Models.Reviews;
using AwesomeBlazor.Validators.Users;
using Blazorise;
using FluentValidation;

namespace AwesomeBlazor.Validators.Reviews
{

    //public class FluentValidationHandler : Blazorise.IValidationHandler
    //{
    //    public void Validate(IValidation validation, object newValidationValue)
    //    {
    //        validation.
    //    }
    //}


    public class ReviewValidator : AbstractValidator<ReviewInsertModel>
    {
        public ReviewValidator()
        {
            RuleFor(t => t.User).SetValidator(new UserInsertValidator());
        }
    }
}
