
using MediatR;
using Project.Application.DTOs;
using Project.Domain.Entities;

namespace Project.Application.Features.Users.Requests
{
    public class CreateUserCommand : IRequest<Response<UsersDTO>>
    {
        public CreateUserDTO NewUser { get; set; }

        public CreateUserCommand(CreateUserDTO newUser)
        {
            NewUser = newUser;
        }
    }
}