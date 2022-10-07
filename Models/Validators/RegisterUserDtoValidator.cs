using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WirtualLibrary.Dtos;
using WirtualLibrary.Services;

namespace WirtualLibrary.Models.Validators
{
    public class RegisterUserDtoValidator : AbstractValidator<RegisterUserDto>
    {
        public RegisterUserDtoValidator(BookDbContext dbContext)
        {
            RuleFor(x => x.Login)
                .NotEmpty()
                .EmailAddress();

            RuleFor(x => x.Password).MinimumLength(6);

            RuleFor(x => x.ConfirmPassword).Equal(e => e.Password);

            RuleFor(x => x.Login)
                .Custom((value, context) =>
                {
                    var emailInUse = dbContext.Users.Any(u => u.Login == value);
                    if (emailInUse)
                    {
                        context.AddFailure("Login", "That login is taken");
                    }
                });
        }
    }
}
