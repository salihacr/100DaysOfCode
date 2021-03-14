using DesignPatterns.CQRS.CQRS.Queries.Request;
using DesignPatterns.CQRS.CQRS.Queries.Response;
using DesignPatterns.CQRS.Models;
using System.Collections.Generic;
using System.Linq;

namespace DesignPatterns.CQRS.CQRS.Handlers.QueryHandlers
{
    public class GetAllProductQueryHandler
    {
        public List<GetAllProductQueryResponse> GetAllProduct(GetAllProductQueryRequest getAllProductQueryRequest)
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
