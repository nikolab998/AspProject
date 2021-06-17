using AspProject.Application.Commands;
using AspProject.Application.DataTransfer;
using AspProject.Application.Exceptions;
using AspProject.DataAccess;
using AspProject.Domain;
using AspProject.Implementation.Validators;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AspProject.Implementation.Commands
{
    public class EfUpdateUserCommand : IUpdateUserCommand
    {
        private readonly AspProjectContext _context;
        private readonly UpdateUserValidator _validator;

        public EfUpdateUserCommand(AspProjectContext context, UpdateUserValidator validator)
        {
            _context = context;
            _validator = validator;
        }

        public int Id => (int)UseCaseEnum.EfUpdateUserCommand;

        public string Name => UseCaseEnum.EfUpdateUserCommand.ToString();

        public void Execute(UserDto dto)
        {
            var id = dto.Id;

            var user = _context.Users.Include(x => x.Posts).Include(x => x.Likes).Include(x => x.Comments)
                        .Include(x => x.UserUseCases).FirstOrDefault(x => x.Id == id);

            if(user == null)
            {
                throw new EntityNotFoundException(id, typeof(User));
            }

            _validator.ValidateAndThrow(dto);

            user.FirstName = dto.FirstName;
            user.LastName = dto.LastName;
            user.Email = dto.Email;
            user.Password = dto.Password;
            user.Username = dto.Username;
            user.ModifidedAt = DateTime.UtcNow;
            _context.SaveChanges();


        }
    }
}
