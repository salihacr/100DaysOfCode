using DesignPatterns.CQRS.CQRS.Commands.Request;
using DesignPatterns.CQRS.CQRS.Commands.Response;
using DesignPatterns.CQRS.CQRS.Handlers.CommandHandlers;
using DesignPatterns.CQRS.CQRS.Handlers.QueryHandlers;
using DesignPatterns.CQRS.CQRS.Queries.Request;
using DesignPatterns.CQRS.CQRS.Queries.Response;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace DesignPatterns.CQRS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly CreateProductCommandHandler _createProductCommandHandler;
        private readonly DeleteProductCommandHandler _deleteProductCommandHandler;
        private readonly GetAllProductQueryHandler _getAllProductQueryHandler;
        private readonly GetByIdProductQueryHandler _getByIdProductQueryHandler;
        public ProductsController(
            CreateProductCommandHandler createProductCommandHandler,
            DeleteProductCommandHandler deleteProductCommandHandler,
            GetAllProductQueryHandler getAllProductQueryHandler,
            GetByIdProductQueryHandler getByIdProductQueryHandler)
        {
            _createProductCommandHandler = createProductCommandHandler;
            _deleteProductCommandHandler = deleteProductCommandHandler;
            _getAllProductQueryHandler = getAllProductQueryHandler;
            _getByIdProductQueryHandler = getByIdProductQueryHandler;
        }
        [HttpGet]
        public IActionResult Get([FromQuery] GetAllProductQueryRequest requestModel)
        {
            List<GetAllProductQueryResponse> allProducts = _getAllProductQueryHandler.GetAllProduct(requestModel);
            return Ok(allProducts);
        }
        [HttpGet("{id}")]
        public IActionResult Get([FromQuery] GetByIdProductQueryRequest requestModel)
        {
            GetByIdProductQueryResponse product = _getByIdProductQueryHandler.GetByIdProduct(requestModel);
            return Ok(product);
        }

        [HttpPost]
        public IActionResult Post([FromBody] CreateProductCommandRequest requestModel)
        {
            CreateProductCommandResponse response = _createProductCommandHandler.CreateProduct(requestModel);
            return Ok(response);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete([FromQuery] DeleteProductCommandRequest requestModel)
        {
            DeleteProductCommandResponse response = _deleteProductCommandHandler.DeleteProduct(requestModel);
            return Ok(response);
        }
    }
}
