using MediatR;
using Microsoft.AspNetCore.Mvc;
using Product.Application.Command.Product.Create;
using Product.Application.Query.CommandQuery.Product.GetAllProduct;
using Product.Application.Query.CommandQuery.Product.GetById;
using System.Threading.Tasks;

namespace Product.API.Controllers
{
    [Route("api/produto")]
    public class ProductController : ControllerBase
    {
        private readonly IMediator _mediator;
        public ProductController(IMediator mediator)
        {
            _mediator = mediator;
        }

        // api/product?query=valoressss
        [HttpGet]
        public async Task<IActionResult> Get(string query)
        {
            var getAllProductQuery = new GetAllProductQueryCommand(query);

            var projects = await _mediator.Send(getAllProductQuery);

            return Ok(projects);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var query = new GetByIdProductQueryCommand(id);

            var result = await _mediator.Send(query);

            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CreateProductCommand productCommand)
        {
            var id = await _mediator.Send(productCommand);

            return CreatedAtAction(nameof(GetById), new { id = id }, productCommand);
        }
    }
}
