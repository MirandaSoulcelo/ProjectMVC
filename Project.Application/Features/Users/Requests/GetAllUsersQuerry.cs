using MediatR;
using Project.Application.DTOs;


namespace Project.Application.Features.Users.Requests
{
    public class GetAllUsersQuerry : IRequest<List<UsersDTO>>
    {

    }
}