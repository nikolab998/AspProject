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
    public class EfGetUseCaseLogsQuery : IGetUseCaseLogsQuery
    {
        private readonly AspProjectContext _context;

        public EfGetUseCaseLogsQuery(AspProjectContext context)
        {
            _context = context;
        }

        public int Id => (int)UseCaseEnum.EfGetUseCaseLogsQuery;

        public string Name => UseCaseEnum.EfGetUseCaseLogsQuery.ToString();

        public PagedResponse<UseCaseLogDto> Execute(UseCaseLogSearch search)
        {
            var query = _context.UseCaseLogs.AsQueryable();

            if(!string.IsNullOrEmpty(search.Actor) || !string.IsNullOrWhiteSpace(search.Actor))
            {
                query = query.Where(x => x.Actor.ToLower().Contains(search.Actor.ToLower()));
            }

            if(!string.IsNullOrWhiteSpace(search.UseCaseName) || !string.IsNullOrEmpty(search.UseCaseName))
            {
                query = query.Where(x => x.UseCaseName.ToLower().Contains(search.UseCaseName));
            }
            
            if(search.DateFrom != null && search.DateFrom >= search.DateTo)
            {
                query = query.Where(x => x.CreatedAt >= search.DateFrom);
            }

            if(search.DateTo != null && search.DateTo > search.DateFrom)
            {
                query = query.Where(x => x.CreatedAt <= search.DateTo);
            }

            var skipCount = search.PerPage * (search.Page - 1);

            var response = new PagedResponse<UseCaseLogDto>
            {
                CurrentPage = search.Page,
                ItemsPerPage = search.PerPage,
                TotalCount = query.Count(),
                Items = query.Skip(skipCount).Take(search.PerPage).Select(x => new UseCaseLogDto
                {
                    Actor = x.Actor,
                    Data = x.Data,
                    Date = x.CreatedAt,
                    UseCaseName = x.UseCaseName
                }).ToList()
            };

            return response;
        }
    }
}
