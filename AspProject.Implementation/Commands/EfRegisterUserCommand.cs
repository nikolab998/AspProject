using AspProject.Application.Commands;
using AspProject.Application.DataTransfer;
using AspProject.Application.Email;
using AspProject.DataAccess;
using AspProject.Implementation.Validators;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace AspProject.Implementation.Commands
{
    public class EfRegisterUserCommand : IRegisterUserCommand
    {
        private readonly AspProjectContext _context;
        private readonly RegisterUserValidator _validator;
        private readonly IEmailSender _sender;

        public EfRegisterUserCommand(AspProjectContext context, RegisterUserValidator validator, IEmailSender sender)
        {
            _context = context;
            _validator = validator;
            _sender = sender;
        }
        public int Id => (int)UseCaseEnum.EfRegisterUserCommand;

        public string Name => UseCaseEnum.EfRegisterUserCommand.ToString();

        public void Execute(RegisterUserDto request)
        {
            _validator.ValidateAndThrow(request);

            var user = new Domain.User
            {
                FirstName = request.FirstName,
                LastName = request.LastName,
                Email = request.Email,
                Username = request.Username,
                Password = request.Password,
                CreatedAt = DateTime.UtcNow,
                ModifidedAt = null,
                DeletedAt = null,
                IsActive = true,
                IsDeleted = false
            };

            user.Password = EasyEncryption.SHA.ComputeSHA256Hash(request.Password);

            _context.Users.Add(user);
            _context.SaveChanges();

            var userUseCases = new List<int> { 5,6,10,11,12,15,16,19,20,21};
            var id = user.Id;
            foreach(var uuc in userUseCases)
            {
                user.UserUseCases.Add(new Domain.UserUseCase
                {
                    UserId = id,
                    UseCaseId = uuc
                });
            }

            _context.SaveChanges();

            _sender.Send(new SendEmailDto
            {
                Content = "<h1>Successfull registration!</h1>",
                SendTo = request.Email,
                Subject = "Registration"
            });
        }
    }
}
