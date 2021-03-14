using CQRS_MediatR.CQRS.Queries.Request;
using CQRS_MediatR.CQRS.Queries.Response;
using CQRS_MediatR.Models;
using MediatR;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace CQRS_MediatR.CQRS.Handlers.QueryHandlers
{
    public class GetAllProductQueryHandler : IRequestHandler<GetAllProductQueryRequest, List<GetAllProductQueryResponse>>
    {
        public async Task<List<GetAllProductQueryResponse>> Handle(GetAllProductQueryRequest request, CancellationToken cancellationToken)
        {
            return ApplicationDbContext.ProductList.Select(product => new GetAllProductQueryResponse
            {
                Id = product.Id,
                Name = product.Name,
                Price = product.Price,
                Quantity = product.Quantity,
                CreateTime = product.CreateTime
            }).ToList();
        }
    }
}
