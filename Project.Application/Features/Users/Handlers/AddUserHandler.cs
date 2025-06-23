
using System.ComponentModel;
using System.Reflection.Metadata.Ecma335;
using MediatR;
using Project.Application.DTOs;
using Project.Application.Features.Users.Requests;
using Project.Application.Interfaces;
using Project.Domain.Entities;
using Microsoft.AspNetCore.Identity;

namespace Project.Application.Features.Users.Handlers
{
    public class AddUserHandler : IRequestHandler<CreateUserCommand, Response<UsersDTO>>
    {
        private readonly IUserRepository _repository;



        public AddUserHandler(IUserRepository repository)
        {
            _repository = repository;
        }

        public async Task<Response<UsersDTO>> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            var passwordHasher = new PasswordHasher<Project.Domain.Entities.Users>();
            var user = new Project.Domain.Entities.Users
            {
                Name = request.NewUser.Name,
                Email = request.NewUser.Email,
                
            };
            user.Password = passwordHasher.HashPassword(user, request.NewUser.Password);

            await _repository.Add(user);

            var userDto = new UsersDTO
            {
                Id = user.Id,
                Name = user.Name,
                Email = user.Email
            };

            return new Response<UsersDTO>
            {
                Data = userDto,
                Message = "Usuário Criado com sucesso",
                Status = true,
            };
        }
    }
}