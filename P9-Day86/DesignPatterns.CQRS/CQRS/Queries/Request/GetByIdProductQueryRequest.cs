using System;
namespace DesignPatterns.CQRS.CQRS.Queries.Request
{
    public class GetByIdProductQueryRequest
    {
        public Guid Id { get; set; }
    }
}
