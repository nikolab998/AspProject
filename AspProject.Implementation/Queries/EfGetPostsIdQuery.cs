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
    public class EfGetPostsIdQuery : IGetPostsIdQuery
    {
        private readonly AspProjectContext _context;

        public EfGetPostsIdQuery(AspProjectContext context)
        {
            _context = context;
        }

        public int Id => (int)UseCaseEnum.EfGetPostIdQuery;

        public string Name => UseCaseEnum.EfGetPostIdQuery.ToString();

        public PostDto Execute(int id)
        {
            var post = _context.Posts.Include(x => x.User).Include(x => x.Comments).Include(x => x.Likes).Include(x => x.Image)
                .Include(x => x.PostCategories).ThenInclude(x => x.Category).FirstOrDefault(x => x.Id == id);

            if(post == null)
            {
                throw new EntityNotFoundException(id, typeof(Post));
            }

            var p = new PostDto
            {
                Id = post.Id,
                Title = post.Title,
                Description = post.Description,
                CreatedAt = post.CreatedAt,
                ModifiedAt = post.ModifidedAt,
                DeletedAt = post.DeletedAt,
                IsActive = post.IsActive,
                UserId = post.UserId,
                ImageId = post.ImageId,
                PostCategories = post.PostCategories.Select(x => x.Category.Name),
                UserId_Likes = post.Likes.Select(x => x.UserId),
                Comments = post.Comments.Select(x => x.Name)
            };

            return p;
        }
    }
}
