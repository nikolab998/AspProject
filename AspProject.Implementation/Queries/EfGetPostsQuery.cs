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
    public class EfGetPostsQuery : IGetPostsQuery
    {
        private readonly AspProjectContext _context;

        public EfGetPostsQuery(AspProjectContext context)
        {
            _context = context;
        }

        public int Id => (int)UseCaseEnum.EfGetPostQuery;

        public string Name => UseCaseEnum.EfGetPostQuery.ToString();

        public PagedResponse<PostDto> Execute(PostSearch search)
        {
            var query = _context.Posts.Include(x => x.User).Include(x => x.Likes).Include(x => x.Comments)
                        .Include(x => x.Image).Include(x => x.PostCategories).ThenInclude(x => x.Category).AsQueryable();

            if (!string.IsNullOrEmpty(search.Name) || !string.IsNullOrWhiteSpace(search.Name))
            {
                query = query.Where(x => x.Title.ToLower().Contains(search.Name.ToLower()) || 
                x.Description.ToLower().Contains(search.Name.ToLower()));
            }

            if (search.CategoryId.HasValue)
            {
                query = query.Where(x => x.PostCategories.Any(x => x.Category.Id == search.CategoryId.Value));
            }

            if (search.UserId.HasValue)
            {
                query = query.Where(x => x.User.Id == search.UserId);
            }

            query = query.Where(x => x.IsActive == true);

            var skipCount = search.PerPage * (search.Page - 1);

            var response = new PagedResponse<PostDto>
            {
                ItemsPerPage = search.PerPage,
                CurrentPage = search.Page,
                TotalCount = query.Count(),
                Items = query.Skip(skipCount).Take(search.PerPage).Select(x => new PostDto
                {
                    Id = x.Id,
                    Title = x.Title,
                    Description = x.Description,
                    CreatedAt = x.CreatedAt,
                    ModifiedAt = x.ModifidedAt,
                    DeletedAt = x.DeletedAt,
                    ImageId = x.ImageId,
                    UserId = x.UserId,
                    PostCategories = x.PostCategories.Select(x => x.Category.Name),
                    UserId_Likes = x.Likes.Select(x => x.UserId),
                    Comments = x.Comments.Select(x => x.Name)
                }).ToList()
            };

            return response;
            
        }
    }
}
