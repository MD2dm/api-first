using Microsoft.AspNetCore.Mvc;
using MediatR;
using ProductCatalog.Resources.Queries;
using ModelCQRS.Resources.Commands;
using ModelCQRS.requiment;


namespace ModelCQRS.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductControllers : ControllerBase
    {
        private readonly IMediator _mediator;

        public ProductControllers(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet(Name = "get-product")]
        public async Task<IActionResult> GetAllProducts()
        {
            try
            {
                var query = new GetAllProductsQuery();
                var response = await _mediator.Send(query);
                return response is not null ? Ok(response) : NotFound();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPost("create-product")]
        public async Task<IActionResult> Create(ProductRecument product)
        {
            try
            {
                var command = new CreateProductCommand()
                {
                    Id = product.Id,
                    ProductName = product.ProductName,
                    Price = product.Price,
                    Image = product.Image,
                    Des = product.Des,
                    CategoryId = product.CategoryId
                };

                var response = await _mediator.Send(command);

                return response is not null ? Ok(response) : NotFound();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpDelete("delete/{id}-product")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var command = new DeleteProductCommand() { Id = id };
                var response = await _mediator.Send(command);

                return response == 1 ? Ok(response) : NotFound();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPut("update/{id}-product")]
        public async Task<IActionResult> Update(int id , ProductRecument product)
        {
            try
            {
                var command = new UpdateProductCommand() 
                {
                    Id = id,
                    ProductName = product.ProductName,
                    Price = product.Price,
                    Image = product.Image,
                    Des = product.Des,
                };
                var response = await _mediator.Send(command);

                return response == 1 ? Ok(response) : NotFound();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}

