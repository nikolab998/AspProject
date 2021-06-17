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
    public class EfGetCategoriesQuery : IGetCategoriesQuery
    {
        private readonly AspProjectContext _context;
        public EfGetCategoriesQuery(AspProjectContext context)
        {
            _context = context;
        }
        public int Id => (int)UseCaseEnum.EfGetCategoryQuery;

        public string Name => UseCaseEnum.EfGetCategoryQuery.ToString();

        public PagedResponse<CategoryDto> Execute(CategorySearch search)
        {
            var query = _context.Categories.AsQueryable();

            if (!string.IsNullOrEmpty(search.Name) || !string.IsNullOrWhiteSpace(search.Name))
            {
                query = query.Where(x => x.Name.ToLower().Contains(search.Name.ToLower()));
            }

            var skipCount = search.PerPage * (search.Page - 1);

            var response = new PagedResponse<CategoryDto>
            {
                CurrentPage = search.Page,
                ItemsPerPage = search.PerPage,
                TotalCount = query.Count(),
                Items = query.Skip(skipCount).Take(search.PerPage).Select(x => new CategoryDto
                {
                    Id = x.Id,
                    Name = x.Name
                }).ToList()
            };

            return response;
            
        }
    }
}
