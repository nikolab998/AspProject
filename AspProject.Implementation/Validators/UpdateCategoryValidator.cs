using AspProject.Application.DataTransfer;
using AspProject.DataAccess;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AspProject.Implementation.Validators
{
    public class UpdateCategoryValidator : AbstractValidator<CategoryDto>
    {
        public UpdateCategoryValidator(AspProjectContext context)
        {
            RuleFor(x => x.Name).NotEmpty().DependentRules(() =>    
            {
                RuleFor(x => x.Name).Must((category, name) => !context.Categories.Any(y => y.Name == name && y.Id != category.Id))
                .WithMessage("This category name is already taken.");
            });
        }
    }
}
