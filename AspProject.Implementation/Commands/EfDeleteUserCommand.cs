using AspProject.Application.Commands;
using AspProject.Application.Exceptions;
using AspProject.DataAccess;
using AspProject.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace AspProject.Implementation.Commands
{
    public class EfDeleteUserCommand : IDeleteUserCommand
    {
        private readonly AspProjectContext _context;

        public EfDeleteUserCommand(AspProjectContext context)
        {
            _context = context;
        }

        public int Id => (int)UseCaseEnum.EfDeleteUserCommand;

        public string Name => UseCaseEnum.EfDeleteUserCommand.ToString();

        public void Execute(int id)
        {
            var user = _context.Users.Find(id);

            if(user == null)
            {
                throw new EntityNotFoundException(id, typeof(User));
            }

            user.DeletedAt = DateTime.UtcNow;
            user.IsDeleted = true;
            user.IsActive = false;
            _context.SaveChanges();
        }
    }
}
