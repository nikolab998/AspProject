using AspProject.Application.DataTransfer;
using AspProject.DataAccess;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AspProject.Implementation.Validators
{
    public class CreateCategoryValidator : AbstractValidator<CategoryDto>
    {
        public CreateCategoryValidator(AspProjectContext context)
        {
            RuleFor(x => x.Name).NotEmpty()
                .Must(name => context.Categories.Any(x => x.Name == name)).WithMessage("Group name already exists.");
        }
    }
}
