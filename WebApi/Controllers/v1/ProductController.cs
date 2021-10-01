using Application.Features.ProductFeatures.Commands;
using Application.Features.ProductFeatures.Queries;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace WebApi.Controllers.v1
{
    /// <summary>
    /// Controller to work with products.
    /// </summary>
    [ApiVersion("1.0")]
    public class ProductController : BaseApiController
    {
        /// <summary>
        /// Creates a new product.
        /// </summary>
        /// <param name="command">Product command</param>
        /// <returns>Created product</returns>
        [HttpPost]
        public async Task<IActionResult> Create(CreateProductCommand command)
        {
            return Ok(await Mediator.Send(command));
        }

        /// <summary>
        /// Gets all Products.
        /// </summary>
        /// <returns>List of products</returns>
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await Mediator.Send(new GetAllProductsQuery()));
        }

        /// <summary>
        /// Gets Product Entity by identifier.
        /// </summary>
        /// <param name="id">Product's identifier.</param>
        /// <returns>Product by ID</returns>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            return Ok(await Mediator.Send(new GetProductByIdQuery { Id = id }));
        }

        /// <summary>
        /// Deletes product entity based on identifier.
        /// </summary>
        /// <param name="id">Product identifier.</param>
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            return Ok(await Mediator.Send(new DeleteProductByIdCommand { Id = id }));
        }
        /// <summary>
        /// Updates the product entity based on identifier.   
        /// </summary>
        /// <param name="id">Product identifier.</param>
        /// <param name="command">Update product command.</param>
        /// <returns>Product's identifier</returns>
        [HttpPut("[action]")]
        public async Task<IActionResult> Update(int id, UpdateProductCommand command)
        {
            if (id != command.Id)
                return BadRequest();

            return Ok(await Mediator.Send(command));
        }
    }
}
