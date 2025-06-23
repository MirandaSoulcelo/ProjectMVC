using MediatR;
using Project.Application.DTOs;
using Project.Application.Features.Users.Requests;
using Project.Application.Interfaces;

namespace Project.Application.Features.Users.Handlers
{
    public class GetAllUsersHandler : IRequestHandler<GetAllUsersQuerry, List<UsersDTO>>
    {
        private readonly IUserRepository _repository;

        public GetAllUsersHandler(IUserRepository repository)
        {

            _repository = repository;
        }


        public async Task<List<UsersDTO>> Handle(GetAllUsersQuerry request, CancellationToken cancellationToken)
        {
            var users = await _repository.GetAllAsync();

            return users.Select(u => new UsersDTO
            {
                Id = u.Id,
                Name = u.Name,
                Email = u.Email
            }).ToList();
        }
    }
}