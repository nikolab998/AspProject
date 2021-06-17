using AspProject.Application.DataTransfer;
using AspProject.DataAccess;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using AspProject.Domain;
using System.Text;

namespace AspProject.Implementation.Validators
{
    public class CreateLikeValidator : AbstractValidator<LikeDto>
    {
        public CreateLikeValidator(AspProjectContext context)
        {
            RuleFor(x => x.PostId).NotEmpty();
            RuleFor(x => x.UserId).NotEmpty().WithMessage("User is required").DependentRules(() =>
            {
                RuleFor(x => x.UserId).Must(y => context.Users.Any(x => x.Id == y));
            }).WithMessage("User is not registered.");
            RuleFor(x => x.Status).NotEmpty().Must(y => Enum.IsDefined(typeof(Like.Stat), y))
                                                .WithMessage(("Status must me 'like' or 'dislike'"));

        }
    }
}
