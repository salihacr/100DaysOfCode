using CQRS_MediatR.CQRS.Commands.Request;
using CQRS_MediatR.CQRS.Commands.Response;
using CQRS_MediatR.Models;
using MediatR;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace CQRS_MediatR.CQRS.Handlers.CommandHandlers
{
    public class DeleteProductCommandHandler : IRequestHandler<DeleteProductCommandRequest, DeleteProductCommandResponse>
    {
        public async Task<DeleteProductCommandResponse> Handle(DeleteProductCommandRequest request, CancellationToken cancellationToken)
        {
            var deleteProduct = ApplicationDbContext.ProductList.FirstOrDefault(p => p.Id == request.Id);
            ApplicationDbContext.ProductList.Remove(deleteProduct);
            return new DeleteProductCommandResponse
            {
                IsSuccess = true
            };
        }
    }
}
