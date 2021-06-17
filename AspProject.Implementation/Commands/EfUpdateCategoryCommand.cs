using AspProject.Application.Commands;
using AspProject.Application.DataTransfer;
using AspProject.Application.Exceptions;
using AspProject.DataAccess;
using AspProject.Domain;
using AspProject.Implementation.Validators;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace AspProject.Implementation.Commands
{
    public class EfUpdateCategoryCommand : IUpdateCategoryCommand
    {
        private readonly AspProjectContext _context;
        private readonly UpdateCategoryValidator _validator;

        public EfUpdateCategoryCommand(AspProjectContext context, UpdateCategoryValidator validator)
        {
            _context = context;
            _validator = validator;
        }

        public int Id => (int)UseCaseEnum.EfUpdateCategoryCommand;

        public string Name => UseCaseEnum.EfUpdateCategoryCommand.ToString();

        public void Execute(CategoryDto dto)
        {
            var id = dto.Id;

            var cat = _context.Categories.Find(id);

            if(cat == null)
            {
                throw new EntityNotFoundException(id, typeof(Category));
            }

            _validator.ValidateAndThrow(dto);

            cat.Name = dto.Name;
            cat.ModifidedAt = DateTime.UtcNow;
            _context.SaveChanges();
        }
    }
}
