using AspProject.Application.Commands;
using AspProject.Application.Exceptions;
using AspProject.DataAccess;
using AspProject.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace AspProject.Implementation.Commands
{
    public class EfDeletePostCommand : IDeletePostCommand
    {
        private readonly AspProjectContext _context;

        public EfDeletePostCommand(AspProjectContext context)
        {
            _context = context;
        }

        public int Id => (int)UseCaseEnum.EfDeletePostCommand;

        public string Name => UseCaseEnum.EfDeletePostCommand.ToString();

        public void Execute(int request)
        {
            var post = _context.Posts.Find(request);

            if(post == null)
            {
                throw new EntityNotFoundException(request, typeof(Post));
            }

            post.DeletedAt = DateTime.UtcNow;
            post.IsActive = false;
            post.IsDeleted = true;
            _context.SaveChanges();
        }
    }
}
