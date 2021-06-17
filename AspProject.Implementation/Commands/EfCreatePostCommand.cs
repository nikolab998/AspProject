using AspProject.Application.Commands;
using AspProject.Application.DataTransfer;
using AspProject.DataAccess;
using AspProject.Implementation.Validators;
using FluentValidation;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace AspProject.Implementation.Commands
{
    public class EfCreatePostCommand : ICreatePostCommand
    {
        private readonly AspProjectContext _context;
        private readonly CreatePostValidator _validator;

        public EfCreatePostCommand(AspProjectContext context, CreatePostValidator validator)
        {
            _context = context;
            _validator = validator;
        }
        public int Id => (int)UseCaseEnum.EfCreatePostCommand;

        public string Name => UseCaseEnum.EfCreatePostCommand.ToString();

        public void Execute(PostDto request)
        {
            _validator.ValidateAndThrow(request);

            var post = new Domain.Post
            {
                Title = request.Title,
                Description = request.Title,
                CreatedAt = DateTime.UtcNow,
                ModifidedAt = null,
                DeletedAt = null,
                IsActive = true,
                UserId = request.UserId,
                ImageId = request.ImageId,
                IsDeleted = false
            };

            _context.Posts.Add(post);
            _context.SaveChanges();
        }
    }
}
