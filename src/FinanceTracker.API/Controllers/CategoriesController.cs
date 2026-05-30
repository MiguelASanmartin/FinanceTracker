using FinanceTracker.Application.Categories;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace FinanceTracker.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CategoriesController : ControllerBase
    {
        private IMediator _mediator;

        public CategoriesController(Mediator mediator)
        {
            _mediator = mediator;
        }

        /// <summary>
        /// Registers a new category
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        [ProducesResponseType(typeof(Guid), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<Guid>> CreateCategory([FromBody] RegisterCategoryCommand request)
        {
            var result = await _mediator.Send(request);

            return this.Created($"api/categories/{result}", result);
        }
    }
}
