using Microsoft.EntityFrameworkCore;
using Project.Application.Interfaces;
using Project.Domain.Entities;
using Project.Infrastructure.Data;

namespace Project.Infrastructure.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly AppDbContext _context;

        public UserRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<Users>> GetAllAsync()
        {
            return await _context.Users.ToListAsync();
        }


       public async Task<Response<Users>> Add(Users user)
        {
            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();

            return new Response<Users>
            {
                Data = user,
                Message = "Usuário adicionado com sucesso",
                Status = true
            };
        }

    }
    
}