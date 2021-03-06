using AwesomeBlazor.Models.Users;
using FluentValidation;

namespace AwesomeBlazor.Validators.Users
{
    public class UserInsertValidator : AbstractValidator<UserInsertModel>
    {
        public UserInsertValidator()
        {
            RuleFor(f => f.FirstName).NotEmpty();
        }
    }
}
