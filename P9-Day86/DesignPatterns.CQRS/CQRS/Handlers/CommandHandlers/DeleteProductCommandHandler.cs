using DesignPatterns.CQRS.CQRS.Commands.Request;
using DesignPatterns.CQRS.CQRS.Commands.Response;
using DesignPatterns.CQRS.Models;
using System.Linq;

namespace DesignPatterns.CQRS.CQRS.Handlers.CommandHandlers
{
    public class DeleteProductCommandHandler
    {
        public DeleteProductCommandResponse DeleteProduct(DeleteProductCommandRequest deleteProductCommandRequest)
        {
            var deleteProduct = ApplicationDbContext.ProductList.FirstOrDefault(p => p.Id == deleteProductCommandRequest.Id);
            ApplicationDbContext.ProductList.Remove(deleteProduct);
            return new DeleteProductCommandResponse
            {
                IsSuccess = true
            };
        }
    }
}
