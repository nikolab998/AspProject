using AspProject.Application.DataTransfer;
using AspProject.Application.Exceptions;
using AspProject.Application.Queries;
using AspProject.DataAccess;
using AspProject.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace AspProject.Implementation.Queries
{
    public class EfGetCategoriesIdQuery : IGetCategoriesIdQuery
    {
        private readonly AspProjectContext _context;

        public EfGetCategoriesIdQuery(AspProjectContext context)
        {
            _context = context;
        }

        public int Id => (int)UseCaseEnum.EfGetCategoryIdQuery;

        public string Name => UseCaseEnum.EfGetCategoryIdQuery.ToString();

        public CategoryDto Execute(int id)
        {
            var cat = _context.Categories.Find(id);

            if(cat == null)
            {
                throw new EntityNotFoundException(id,typeof(Category));
            }

            var catdto = new CategoryDto
            {
                Id = cat.Id,
                Name = cat.Name
            };

            return catdto;
        }
    }
}
