using AspProject.Application.DataTransfer;
using AspProject.DataAccess;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AspProject.Implementation.Validators
{
    public class UpdatePostValidator : AbstractValidator<PostDto>
    {
        public UpdatePostValidator(AspProjectContext context)
        {
            RuleFor(x => x.Title).NotEmpty().WithMessage("Title is required");
            RuleFor(x => x.Description).NotEmpty().WithMessage("Description is required");
            RuleFor(x => x.UserId).NotEmpty().DependentRules(() =>
            {
                RuleFor(x => x.UserId).Must(y =>
                {
                    return context.Users.Any(x => x.Id == y);
                });
             });
        }
    }
}
