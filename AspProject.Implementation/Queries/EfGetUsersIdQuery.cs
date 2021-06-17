using AspProject.Application.DataTransfer;
using AspProject.Application.Exceptions;
using AspProject.Application.Queries;
using AspProject.DataAccess;
using AspProject.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AspProject.Implementation.Queries
{
    public class EfGetUsersIdQuery : IGetUsersIdQuery
    {
        private readonly AspProjectContext _context;

        public EfGetUsersIdQuery(AspProjectContext context)
        {
            _context = context;
        }

        public int Id => (int)UseCaseEnum.EfGetUserIdQuery;

        public string Name => UseCaseEnum.EfGetUserIdQuery.ToString();

        public UserDto Execute(int id)
        {
            var user = _context.Users.Include(x => x.Posts).Include(x => x.Likes).Include(x => x.Comments)
                        .Include(x => x.UserUseCases).FirstOrDefault(x => x.Id == id);

            if(user == null)
            {
                throw new EntityNotFoundException(id, typeof(User));
            }

            var userdto = new UserDto
            {
                Id = user.Id,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Email = user.Email,
                Username = user.Username,
                Password = user.Password,
                Posts = user.Posts.Select(x => x.Title),
                Likes = user.Likes.Select(x => x.PostId),
                Comments = user.Comments.Select(x => x.Name),
                UserUsesCases = user.UserUseCases.Select(x => x.Id)
            };
           return userdto;
        }
    }
}
