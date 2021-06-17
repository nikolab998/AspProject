using AspProject.Application.Commands;
using AspProject.Application.Exceptions;
using AspProject.DataAccess;
using AspProject.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace AspProject.Implementation.Commands
{
    public class EfDeleteCategoryCommand : IDeleteCategoryCommand
    {
        private readonly AspProjectContext _context;

        public EfDeleteCategoryCommand(AspProjectContext context)
        {
            _context = context;
        }

        public int Id => (int)UseCaseEnum.EfDeleteCategoryCommand;

        public string Name => UseCaseEnum.EfDeleteCategoryCommand.ToString();

        public void Execute(int request)
        {
            var group = _context.Categories.Find(request);

            if(group == null)
            {
                throw new EntityNotFoundException(request,typeof(Category));
            }
            group.DeletedAt = DateTime.UtcNow;
            group.IsActive = false;
            group.IsDeleted = true;
            _context.SaveChanges();
        }
    }
}
