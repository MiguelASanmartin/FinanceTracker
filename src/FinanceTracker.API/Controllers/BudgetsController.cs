using FinanceTracker.Application.Budgets;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace FinanceTracker.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BudgetsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public BudgetsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        /// <summary>
        /// Registers a new budget
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        [ProducesResponseType(typeof(Guid), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<Guid>> CreateBudget([FromBody] RegisterBudgetCommand request)
        {
            var result = await _mediator.Send(request);

            return this.Created($"api/budgets/{result}", result);
        }

        /// <summary>
        /// Increases a budget total expense
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPut]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult> IncreaseBudget([FromBody] IncreaseBudgetCommand request)
        {
            var result = await _mediator.Send(request);

            return this.NoContent();
        }

        /// <summary>
        /// Decreases a budget total expense
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPut]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult> DecreaseBudget([FromBody] DecreaseBudgetCommand request)
        {
            var result = await _mediator.Send(request);

            return this.NoContent();
        }
    }
}
