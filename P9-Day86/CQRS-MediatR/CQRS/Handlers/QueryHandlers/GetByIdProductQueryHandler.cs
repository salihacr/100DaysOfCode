using CQRS_MediatR.CQRS.Queries.Request;
using CQRS_MediatR.CQRS.Queries.Response;
using CQRS_MediatR.Models;
using MediatR;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace CQRS_MediatR.CQRS.Handlers.QueryHandlers
{
    public class GetByIdProductQueryHandler : IRequestHandler<GetByIdProductQueryRequest, GetByIdProductQueryResponse>
    {
        public async Task<GetByIdProductQueryResponse> Handle(GetByIdProductQueryRequest request, CancellationToken cancellationToken)
        {
            var product = ApplicationDbContext.ProductList.FirstOrDefault(p => p.Id == request.Id);
            return new GetByIdProductQueryResponse
            {
                Id = product.Id,
                Name = product.Name,
                Price = product.Price,
                Quantity = product.Quantity,
                CreateTime = product.CreateTime
            };
        }
    }
}
