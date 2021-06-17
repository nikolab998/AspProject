using AspProject.Application.DataTransfer;
using AspProject.DataAccess;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AspProject.Implementation.Validators
{
    public class UpdateUserValidator : AbstractValidator<UserDto>
    {
        public UpdateUserValidator(AspProjectContext context)
        {
            RuleFor(x => x.FirstName).NotEmpty();
            RuleFor(x => x.LastName).NotEmpty();
            RuleFor(x => x.Email).NotEmpty().DependentRules(() => 
            {
                RuleFor(x => x.Email).Must((user, email) => !context.Users.Any(y => y.Email == email && y.Id != user.Id))
               .WithMessage("This email already exists.");
            });
            RuleFor(x => x.Username).NotEmpty().DependentRules(() => 
            {
                RuleFor(x => x.Username).Must((user, username) => !context.Users.Any(y => y.Username == username && y.Id != user.Id))
               .WithMessage("This username already exists.");
            });
            RuleFor(x => x.Password).NotEmpty();

        }
    }
}
