using System;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Zip.Api.Models;
using Zip.Business.Users.Commands.CreateUser;
using Zip.Business.Users.Queries.GetUserById;
using Zip.Business.Users.Queries.GetUsers;

namespace Zip.Api.Controllers
{
    [ApiController]
    public class UserController : ControllerBase
    {
        private IMediator Mediator { get; }

        public UserController(IMediator mediator)
        {
            Mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        [HttpGet("/users")]
        public async Task<IActionResult> Index()
        {
            IActionResult result = null;

            var response = await Mediator.Send(new GetUsersRequest());

            result = new OkObjectResult(response);

            return result;
        }

        [HttpGet("/users/{id}")]
        public async Task<IActionResult> Index(Guid id)
        {
            IActionResult result = null;

            var response = await Mediator.Send(new GetUserByIdRequest() { UserId = id });

            result = new OkObjectResult(response);

            return result;
        }

        [HttpPost("/users")]
        public async Task<IActionResult> Post(CreateUserViewModel model)
        {
            IActionResult result = null;

            var response = await Mediator.Send(new CreateUserRequest() { Name = model.Name, Email = model.Email, Salary = model.Salary, Expense = model.Expense });

            result = new OkObjectResult(response);

            return result;
        }
    }
}