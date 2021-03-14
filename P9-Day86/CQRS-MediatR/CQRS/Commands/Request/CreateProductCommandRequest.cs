using CQRS_MediatR.CQRS.Commands.Response;
using MediatR;

namespace CQRS_MediatR.CQRS.Commands.Request
{
    public class CreateProductCommandRequest : IRequest<CreateProductCommandResponse>
    {
        public string Name { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
    }
}
