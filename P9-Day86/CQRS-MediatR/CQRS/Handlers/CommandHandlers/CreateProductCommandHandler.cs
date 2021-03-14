using CQRS_MediatR.CQRS.Commands.Request;
using CQRS_MediatR.CQRS.Commands.Response;
using CQRS_MediatR.Models;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace CQRS_MediatR.CQRS.Handlers.CommandHandlers
{
    public class CreateProductCommandHandler : IRequestHandler<CreateProductCommandRequest, CreateProductCommandResponse>
    {
        public async Task<CreateProductCommandResponse> Handle(CreateProductCommandRequest request, CancellationToken cancellationToken)
        {
            var id = Guid.NewGuid();
            ApplicationDbContext.ProductList.Add(new()
            {
                Id = id,
                Name = request.Name,
                Price = request.Price,
                Quantity = request.Quantity,
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
