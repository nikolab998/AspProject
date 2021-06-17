using AspProject.Application;
using AspProject.Application.Commands;
using AspProject.Application.Exceptions;
using AspProject.DataAccess;
using AspProject.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AspProject.Implementation.Commands
{
    public class EfDeleteCommentCommand : IDeleteCommentCommand
    {
        private readonly AspProjectContext _context;

        public EfDeleteCommentCommand(AspProjectContext context)
        {
            _context = context;
        }

        public int Id => (int)UseCaseEnum.EfDeleteCommentCommand;

        public string Name => UseCaseEnum.EfDeleteCommentCommand.ToString();

        public void Execute(int id)
        {
            var comment = _context.Comments.Find(id);

            if (comment == null)
            {
                throw new EntityNotFoundException(id, typeof(Comment));
            }
            comment.DeletedAt = DateTime.UtcNow;
            comment.IsDeleted = true;
            comment.IsActive = false;
            _context.SaveChanges();
        }
    }
}
