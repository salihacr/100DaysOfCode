using DesignPatterns.CQRS.CQRS.Commands.Request;
using DesignPatterns.CQRS.CQRS.Commands.Response;
using DesignPatterns.CQRS.Models;
using System;

namespace DesignPatterns.CQRS.CQRS.Handlers.CommandHandlers
{
    public class CreateProductCommandHandler
    {
        public CreateProductCommandResponse CreateProduct(CreateProductCommandRequest createProductCommandRequest)
        {
            var id = Guid.NewGuid();
            ApplicationDbContext.ProductList.Add(new()
            {
                Id = id,
                Name = createProductCommandRequest.Name,
                Price = createProductCommandRequest.Price,
                Quantity = createProductCommandRequest.Quantity,
                CreateTime = DateTime.Now
            });
            return new CreateProductCommandResponse
            {
                IsSuccess = true,
                ProductId = id
            };
        }
    }
}
