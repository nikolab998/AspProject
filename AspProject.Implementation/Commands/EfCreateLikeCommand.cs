using AspProject.Application;
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
    public class EfCreateLikeCommand : ICreateLikeCommand
    {
        private readonly AspProjectContext _context;
        private readonly CreateLikeValidator _validator;

        public EfCreateLikeCommand(AspProjectContext context,CreateLikeValidator validator)
        {
            _context = context;
            _validator = validator;
        }

        public int Id => (int)UseCaseEnum.EfCreateLikeCommand;

        public string Name => UseCaseEnum.EfCreateLikeCommand.ToString();

        public void Execute(LikeDto request)
        {

            _validator.ValidateAndThrow(request);

            var liked = _context.Likes.Where(x => x.UserId == request.UserId && x.Post.Id == request.PostId).FirstOrDefault();

            if(liked == null)
            {
                var like = new Like
                {
                    UserId = request.UserId,
                    PostId = request.PostId,
                    Status = request.Status,
                    CreatedAt = DateTime.UtcNow,
                    IsActive = true,
                    IsDeleted = false
                };

                _context.Likes.Add(like);
                _context.SaveChanges();
            }
            else
            {
                liked.Status = request.Status;
                liked.ModifidedAt = DateTime.UtcNow;
                _context.SaveChanges();
            }

        }
    }
}
