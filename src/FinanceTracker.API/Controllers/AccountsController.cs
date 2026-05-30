using FinanceTracker.Application.Accounts;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace FinanceTracker.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AccountsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public AccountsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        /// <summary>
        /// Registers a new account
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        [ProducesResponseType(typeof(Guid), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<Guid>> CreateAccount([FromBody] RegisterAccountCommand request)
        {
            var result = await _mediator.Send(request);

            return this.Created($"api/accounts/{result}", result);
        }
    }
}
