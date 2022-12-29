using AHY.CQRS.WebApi.CQRS.Results;
using MediatR;

namespace AHY.CQRS.WebApi.CQRS.Querys
{
    public class GetStudentsQuery : IRequest<IEnumerable<GetStudentsQueryResult>>
    {

    }
}
