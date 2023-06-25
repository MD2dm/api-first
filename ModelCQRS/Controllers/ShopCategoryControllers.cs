using Microsoft.AspNetCore.Mvc;
using MediatR;
using ModelCQRS.Resources.Queries.Category;
using ModelCQRS.requiment;
using ModelCQRS.Resources.Commands.Category;

namespace ModelCQRS.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ShopCategoryControllers : ControllerBase
	{
        private readonly IMediator _mediator;

        public ShopCategoryControllers(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet(Name = "get-category")]
        public async Task<IActionResult> GetAllCategories()
        {
            try
            {
                var query = new GetAllCategoriesQuery();
                var response = await _mediator.Send(query);
                return response is not null ? Ok(response) : NotFound();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPost("create-category")]
        public async Task<IActionResult> Create(CategoryRecument category)
        {
            try
            {
                var command = new CreateCategoryCommand()
                {
                    Id = category.Id,
                    CategoryName = category.NameCategory
                };

                var reponse = await _mediator.Send(command);

                return reponse is not null ? Ok(reponse) : NotFound();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpDelete("delete/{id}-category")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var command = new DeleteProductCommand() { Id = id };
                var response = await _mediator.Send(command);

                return response == 1 ? Ok(response) : NotFound();
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPut("update/{id}-category")]
        public async Task<IActionResult> Update(int id, CategoryRecument category)
        {
            try
            {
                var command = new UpdateCategoryCommand()
                {
                    Id = id,
                    NameCategory = category.NameCategory
                };
                var reponse = await _mediator.Send(command);

                return reponse == 1 ? Ok(reponse) : NotFound();
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}

