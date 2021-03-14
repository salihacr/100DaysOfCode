using DesignPatterns.CQRS.CQRS.Queries.Request;
using DesignPatterns.CQRS.CQRS.Queries.Response;
using DesignPatterns.CQRS.Models;
using System.Linq;

namespace DesignPatterns.CQRS.CQRS.Handlers.QueryHandlers
{
    public class GetByIdProductQueryHandler
    {
        public GetByIdProductQueryResponse GetByIdProduct(GetByIdProductQueryRequest getByIdProductQueryRequest)
        {
            var product = ApplicationDbContext.ProductList.FirstOrDefault(p => p.Id == getByIdProductQueryRequest.Id);
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
