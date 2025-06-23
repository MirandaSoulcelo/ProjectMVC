

using Project.Domain.Entities;

namespace Project.Application.Interfaces
{
    public interface IUserRepository
    {
        Task<List<Users>> GetAllAsync();

        Task<Response<Users>> Add(Users users);
    }
}