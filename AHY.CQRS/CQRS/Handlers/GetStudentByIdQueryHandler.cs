using AHY.CQRS.Data;
using AHY.CQRS.WebApi.CQRS.Querys;
using AHY.CQRS.WebApi.CQRS.Results;
using MediatR;

namespace AHY.CQRS.WebApi.CQRS.Handlres
{
    public class GetStudentByIdQueryHandler : IRequestHandler<GetStudentByIdQuery, GetStudentByIdQueryResult>
    {
        private readonly StudentContext _context;

        public GetStudentByIdQueryHandler(StudentContext context)
        {
            _context = context;
        }

        public async Task<GetStudentByIdQueryResult> Handle(GetStudentByIdQuery request, CancellationToken cancellationToken)
        {
            var student = await _context.Set<Student>().FindAsync(request.Id);
            if (student != null)
            {
                return new GetStudentByIdQueryResult
                {
                    Age = student.Age,
                    Name = student.Name,
                    Surname = student.Surname,
                };
            }
            else
            {
                return null;
            }
        }

        //public GetStudentByIdQueryResult Handle(GetStudentByIdQuery query)
        //{
        //    var student = _context.Set<Student>().Find(query.Id);
        //    if (student != null)
        //    {
        //        return new GetStudentByIdQueryResult
        //        {
        //            Age = student.Age,
        //            Name = student.Name,
        //            Surname = student.Surname,
        //        };
        //    }
        //    else
        //    {
        //        return null;
        //    }

        //}
    }
}
