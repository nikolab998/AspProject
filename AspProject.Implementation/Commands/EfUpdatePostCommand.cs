using AspProject.Application.Commands;
using AspProject.Application.DataTransfer;
using AspProject.Application.Exceptions;
using AspProject.DataAccess;
using AspProject.Domain;
using AspProject.Implementation.Validators;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AspProject.Implementation.Commands
{
    public class EfUpdatePostCommand : IUpdatePostCommand
    {
        private readonly AspProjectContext _context;
        private readonly UpdatePostValidator _validator;

        public EfUpdatePostCommand(AspProjectContext context, UpdatePostValidator validator)
        {
            _context = context;
            _validator = validator;
        }

        public int Id => (int)UseCaseEnum.EfUpdatePostCommand;

        public string Name => UseCaseEnum.EfUpdatePostCommand.ToString();

        public void Execute(PostDto request)
        {
            var id = request.Id;
            var post = _context.Posts.Include(x => x.User).Include(x => x.Comments).Include(x => x.Likes)
                        .Include(x => x.PostCategories).ThenInclude(x => x.Category)
                        .FirstOrDefault(x => x.Id == id);

            if(post == null)
            {
                throw new EntityNotFoundException(id, typeof(Post));
            }

            _validator.ValidateAndThrow(request);

            post.Title = request.Title;
            post.Description = request.Description;
            post.UserId = request.UserId;
            post.CreatedAt = request.CreatedAt;
            post.ModifidedAt = DateTime.UtcNow;
            post.DeletedAt = request.DeletedAt;

            _context.SaveChanges();
        }
    }
}
