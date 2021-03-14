using CQRS_MediatR.CQRS.Commands.Request;
using CQRS_MediatR.CQRS.Commands.Response;
using CQRS_MediatR.CQRS.Queries.Request;
using CQRS_MediatR.CQRS.Queries.Response;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CQRS_MediatR.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        IMediator _mediator;

        public ProductsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] GetAllProductQueryRequest requestModel)
        {
            List<GetAllProductQueryResponse> allProducts = await _mediator.Send(requestModel);
            return Ok(allProducts);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get([FromQuery] GetByIdProductQueryRequest requestModel)
        {
            GetByIdProductQueryResponse product = await _mediator.Send(requestModel);
            return Ok(product);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CreateProductCommandRequest requestModel)
        {
            CreateProductCommandResponse response = await _mediator.Send(requestModel);
            return Ok(response);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromQuery] DeleteProductCommandRequest requestModel)
        {
            DeleteProductCommandResponse response = await _mediator.Send(requestModel);
            return Ok(response);
        }
    }
}
