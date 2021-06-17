using AspProject.Application.DataTransfer;
using AspProject.Application.Queries;
using AspProject.Application.Searches;
using AspProject.DataAccess;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AspProject.Implementation.Queries
{
    public class EfGetUsersQuery : IGetUsersQuery
    {
        private readonly AspProjectContext _context;

        public EfGetUsersQuery(AspProjectContext context)
        {
            _context = context;
        }

        public int Id => (int)UseCaseEnum.EfGetUserQuery;

        public string Name => UseCaseEnum.EfGetUserQuery.ToString();

        public PagedResponse<UserDto> Execute(UserSearch search)
        {
            var users = _context.Users.Include(x => x.Likes).Include(x => x.Comments).Include(x => x.UserUseCases)
                .Include(x => x.Posts).AsQueryable();

            if (!string.IsNullOrEmpty(search.Name) || !string.IsNullOrWhiteSpace(search.Name))
            {
                search.Name = search.Name.ToLower();
                users = users.Where(x => x.FirstName.ToLower().Contains(search.Name) || x.LastName.ToLower().Contains(search.Name) ||
                x.Username.ToLower().Contains(search.Name) || x.Email.ToLower().Contains(search.Name));
            }

            var skipCount = search.PerPage * (search.Page - 1);

            var response = new PagedResponse<UserDto>
            {
                CurrentPage = search.Page,
                ItemsPerPage = search.PerPage,
                TotalCount = users.Count(),
                Items = users.Skip(skipCount).Take(search.PerPage).Select(x => new UserDto
                {
                    Id = x.Id,
                    FirstName = x.FirstName,
                    LastName = x.LastName,
                    Username = x.Username,
                    Email = x.Email,
                    Password = x.Password,
                    Posts = x.Posts.Select(x => x.Title),
                    Likes = x.Likes.Select(x => x.PostId),
                    Comments = x.Comments.Select(x => x.Name),
                    UserUsesCases = x.UserUseCases.Select(x => x.Id)
                })
            };

            return response;
        }
    }
}
