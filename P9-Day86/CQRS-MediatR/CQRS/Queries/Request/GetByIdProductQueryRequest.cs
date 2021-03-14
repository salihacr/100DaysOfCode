using CQRS_MediatR.CQRS.Queries.Response;
using MediatR;
using System;
namespace CQRS_MediatR.CQRS.Queries.Request
{
    public class GetByIdProductQueryRequest : IRequest<GetByIdProductQueryResponse>
    {
        public Guid Id { get; set; }
    }
}
