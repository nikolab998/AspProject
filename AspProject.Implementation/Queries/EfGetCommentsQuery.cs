using AspProject.Application.DataTransfer;
using AspProject.Application.Queries;
using AspProject.Application.Searches;
using AspProject.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AspProject.Implementation.Queries
{
    public class EfGetCommentsQuery : IGetCommentsQuery
    {
        private readonly AspProjectContext _context;

        public EfGetCommentsQuery(AspProjectContext context)
        {
            _context = context;
        }

        public int Id => (int)UseCaseEnum.EfGetCommentQuery;

        public string Name => UseCaseEnum.EfGetCommentQuery.ToString();

        public PagedResponse<CommentDto> Execute(CommentSearch search)
        {
            var query = _context.Comments.AsQueryable();

            if (!string.IsNullOrEmpty(search.Name) || !string.IsNullOrWhiteSpace(search.Name))
            {
                search.Name = search.Name.ToLower();
                query = query.Where(x => x.Name.ToLower().Contains(search.Name));
            }

            var skipCount = search.PerPage * (search.Page - 1);

            var response = new PagedResponse<CommentDto>
            {
                CurrentPage = search.Page,
                ItemsPerPage = search.PerPage,
                TotalCount = query.Count(),
                Items = query.Skip(skipCount).Take(search.PerPage).Select(x => new CommentDto
                {
                    Id = x.Id,
                    Name = x.Name
                }).ToList()
            };
            return response;
        }
    }
}
