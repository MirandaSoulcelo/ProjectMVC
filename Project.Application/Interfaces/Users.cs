using Project.Application.DTOs;
using Project.Domain.Entities;

namespace Project.Application.Interfaces
{
    public interface IUsersInterface
    {
        Task<Response<List<UsersDTO>>> GetAll();
    }
}