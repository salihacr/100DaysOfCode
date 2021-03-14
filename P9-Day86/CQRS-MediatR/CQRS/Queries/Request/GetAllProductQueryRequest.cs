using CQRS_MediatR.CQRS.Queries.Response;
using MediatR;
using System.Collections.Generic;

namespace CQRS_MediatR.CQRS.Queries.Request
{
    public class GetAllProductQueryRequest : IRequest<List<GetAllProductQueryResponse>>
    {

    }
}
