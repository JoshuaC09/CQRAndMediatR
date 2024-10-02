using CrqsMediatrExample.Command;
using CrqsMediatrExample.Queries;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CrqsMediatrExample.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IMediator _mediator;
        public ProductsController(IMediator mediator, FakeDataStore fakeDataStore)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllProducts()
        {
            var products = await _mediator.Send(new GetProductQuery());

            return Ok(products);
        }

        [HttpGet("{id:int}", Name = "GetProductById")]

        public async Task<IActionResult> GetProductById(int id)
        {
            var productToReturn = await _mediator.Send(new GetProductByIdQuery(id));

            return CreatedAtRoute("GetProductById",new {id=productToReturn.Id}, productToReturn);
        }

        

        [HttpPost]
        public async Task<IActionResult> AddProduct([FromBody] Product product)
        {
            var newProduct = _mediator.Send(new AddProductCommand(product));

            return Ok(newProduct);  
        }

        [HttpPut]

        public async Task<IActionResult> UpdateProduct([FromBody] Product product)
        {
            var updatedProduct = _mediator.Send(new UpdateProductCommand(product.Id,product.Name));
            
            return Ok(updatedProduct);
        }

        [HttpDelete]

        public async Task<IActionResult> DeleteProduct(int id)
        {
            var deletedProduct = await _mediator.Send( new DeteleteProductByIdCommand(id));

            return Ok(deletedProduct);
        }
    }
}
