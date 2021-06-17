using AspProject.Application.DataTransfer;
using AspProject.DataAccess;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AspProject.Implementation.Validators
{
    public class CreateCommentValidator : AbstractValidator<CommentDto>
    {
        public CreateCommentValidator(AspProjectContext context)
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("Comment is required");
            RuleFor(x => x.PostId).NotEmpty().DependentRules(() =>
            {
                RuleFor(x => x.PostId).Must(y => context.Posts.Any(b => b.Id == y)).WithMessage("Post doesn't exists.");
            });
            RuleFor(x => x.UserId).NotEmpty().DependentRules(() =>
            {
                RuleFor(x => x.UserId).Must(y => context.Users.Any(b => b.Id == y)).WithMessage("User doesn't exists.");
            });
        }
    }
}
