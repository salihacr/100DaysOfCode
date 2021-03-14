using CQRS_MediatR.CQRS.Commands.Response;
using MediatR;
using System;
namespace CQRS_MediatR.CQRS.Commands.Request
{
    public class DeleteProductCommandRequest : IRequest<DeleteProductCommandResponse>
    {
        public Guid Id { get; set; }
    }
}
