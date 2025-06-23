
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Project.Application.DTOs;
using Project.Application.Features.Users.Requests;
using ProjectMVC.ViewModels;


namespace ProjectMVC.Controllers
{
    [Route("[controller]")]
    public class UsersController : Controller
    {
        private readonly IMediator _mediator;

        public UsersController(IMediator mediator)
        {
            _mediator = mediator;
        }


        [HttpGet("")]
        public async Task<IActionResult> Index()
        {
            var usersDTO = await _mediator.Send(new GetAllUsersQuerry()) ?? new List<UsersDTO>(); //evitando null


            var usersVm = usersDTO.Select(u => new UserViewModel
            {
                Id = u.Id,
                Name = u.Name,
                Email = u.Email,
            }
            ).ToList();

            return View(usersVm);
        }


        [HttpGet("Error")]
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View("Error!");
        }



        [HttpGet("Create")]
        public IActionResult Create()
        {
            return View(new CreateUserDTO());
        }
        


        [HttpPost("Create")]
        public async Task<IActionResult> Create(CreateUserDTO dto)
        {
            if (!ModelState.IsValid)
                return View(dto);

            var command = new CreateUserCommand(dto);
            var result = await _mediator.Send(command);

            if (!result.Status)
            {
                ModelState.AddModelError(string.Empty, result.Message);
                return View(dto);
            }

            return RedirectToAction("Index");
        }


    }
}