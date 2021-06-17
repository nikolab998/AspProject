using AspProject.Application;
using AspProject.Application.DataTransfer;
using AspProject.Application.Exceptions;
using AspProject.Application.Queries;
using AspProject.DataAccess;
using AspProject.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace AspProject.Implementation.Queries
{
    public class EfGetCommentIdQuery : IGetCommentIdQuery
    {
        private readonly AspProjectContext _context;

        public EfGetCommentIdQuery(AspProjectContext context)
        {
            _context = context;
        }

        public int Id => (int)UseCaseEnum.EfGetCommentIdQuery;

        public string Name => UseCaseEnum.EfGetCommentIdQuery.ToString();

        public CommentDto Execute(int id)
        {
            var comment = _context.Comments.Find(id);

            if (comment == null)
            {
                throw new EntityNotFoundException(id, typeof(Comment));
            }

            var comm = new CommentDto
            {
                Id = comment.Id,
                UserId = comment.UserId,
                PostId = comment.PostId,
                Name = comment.Name
            };

            return comm;
        }
    }
}
