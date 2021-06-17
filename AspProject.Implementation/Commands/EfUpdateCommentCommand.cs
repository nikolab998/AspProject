using AspProject.Application.Commands;
using AspProject.Application.DataTransfer;
using AspProject.Application.Exceptions;
using AspProject.DataAccess;
using AspProject.Domain;
using AspProject.Implementation.Validators;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace AspProject.Implementation.Commands
{
    public class EfUpdateCommentCommand : IUpdateCommentCommand
    {
        private readonly AspProjectContext _context;
        private readonly UpdateCommentValidator _validator;
        public EfUpdateCommentCommand(AspProjectContext context,UpdateCommentValidator validator)
        {
            _context = context;
            _validator = validator;
        }

        public int Id => (int)UseCaseEnum.EfUpdateCommentCommand;

        public string Name => UseCaseEnum.EfUpdateCommentCommand.ToString();

        public void Execute(CommentDto request)
        {
            var id = request.Id;

            var comment = _context.Comments.Find(id);

            if(comment == null)
            {
                throw new EntityNotFoundException(id, typeof(Comment));
            }

            _validator.ValidateAndThrow(request);

            comment.Name = request.Name;
            comment.ModifidedAt = DateTime.UtcNow;
            _context.SaveChanges();
        }
    }
}
