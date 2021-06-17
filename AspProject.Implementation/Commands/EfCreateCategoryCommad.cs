using System;
using AspProject.Application.Commands;
using System.Collections.Generic;
using System.Text;
using AspProject.DataAccess;
using AspProject.Implementation.Validators;
using AspProject.Application.DataTransfer;
using FluentValidation;

namespace AspProject.Implementation.Commands
{
    public class EfCreateCategoryCommad : ICreateCategoryCommand
    {
        private readonly AspProjectContext _context;
        private readonly CreateCategoryValidator _validator;

        public EfCreateCategoryCommad(AspProjectContext context,CreateCategoryValidator validator)
        {
            _context = context;
            _validator = validator;
        }

        public int Id => (int)UseCaseEnum.EfCreateCategoryCommand;
        public string Name => UseCaseEnum.EfCreateCategoryCommand.ToString();

        public void Execute(CategoryDto request)
        {
            _validator.ValidateAndThrow(request);

            var category = new Domain.Category
            {
                Name = request.Name,
                CreatedAt = DateTime.UtcNow,
                ModifidedAt = null,
                DeletedAt = null,
                IsDeleted = false,
                IsActive = true
            };

            _context.Categories.Add(category);
            _context.SaveChanges();
        }
    }
}
