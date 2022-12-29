using AHY.CQRS.WebApi.CQRS.Results;
using MediatR;

namespace AHY.CQRS.WebApi.CQRS.Querys
{
    public class GetStudentByIdQuery : IRequest<GetStudentByIdQueryResult>
    {
        public int Id { get; set; }

        public GetStudentByIdQuery(int id)
        {
            Id = id;
        }
    }
}
