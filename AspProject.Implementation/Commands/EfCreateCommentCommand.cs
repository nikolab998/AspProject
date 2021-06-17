using AspProject.Application.Commands;
using AspProject.Application.DataTransfer;
using AspProject.DataAccess;
using AspProject.Implementation.Validators;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace AspProject.Implementation.Commands
{
    public class EfCreateCommentCommand : ICreateCommentCommand
    {
        private readonly AspProjectContext _context;
        private readonly CreateCommentValidator _validator;

        public EfCreateCommentCommand(AspProjectContext context, CreateCommentValidator validator)
        {
            _context = context;
            _validator = validator;
        }

        public int Id => (int)UseCaseEnum.EfCreateCommentCommand;

        public string Name => UseCaseEnum.EfCreateCommentCommand.ToString();

        public void Execute(CommentDto dto)
        {
            _validator.ValidateAndThrow(dto);

            var comment = new Domain.Comment
            {
                Name = dto.Name,
                UserId = dto.UserId,
                PostId = dto.PostId,
                CreatedAt = DateTime.UtcNow,
                ModifidedAt = null,
                DeletedAt = null,
                IsDeleted = false,
                IsActive = true
            };

            _context.Comments.Add(comment);
            _context.SaveChanges();
        }
    }
}
