using AspProject.Application.DataTransfer;
using AspProject.DataAccess;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AspProject.Implementation.Validators
{
    public class UpdateCommentValidator : AbstractValidator<CommentDto>
    {
        public UpdateCommentValidator(AspProjectContext context)
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("Comment is required");
            RuleFor(x => x.PostId).NotEmpty().DependentRules(() =>
            {
                RuleFor(x => x.PostId).Must(x => context.Posts.Any(x => x.Id == x.Id)).WithMessage("Post doesnt exists.");
            });
            RuleFor(x => x.UserId).NotEmpty().DependentRules(() =>
            {
                RuleFor(x => x.UserId).Must(x => context.Users.Any(x => x.Id == x.Id)).WithMessage("User doesnt exists.");
            });
        }
    }
}
