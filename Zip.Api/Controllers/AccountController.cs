using System;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Zip.Api.Models;
using Zip.Business.Accounts.Commands.CreateAccount;
using Zip.Business.Accounts.Queries.GetAccounts;

namespace Zip.Api.Controllers
{
    [ApiController]
    public class AccountController : ControllerBase
    {
        private IMediator Mediator { get; }

        public AccountController(IMediator mediator)
        {
            Mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        [HttpGet("/accounts")]
        public async Task<IActionResult> Index()
        {
            IActionResult result = null;

            var response = await Mediator.Send(new GetAccountsRequest());

            result = new OkObjectResult(response);

            return result;
        }

        [HttpPost("/accounts")]
        public async Task<IActionResult> Post(CreateAccountViewModel model)
        {
            IActionResult result = null;

            var response = await Mediator.Send(new CreateAccountRequest() { UserId = model.UserId });

            result = new OkObjectResult(response);

            return result;
        }
    }
}