using AHY.CQRS.Data;
using AHY.CQRS.WebApi.CQRS.Querys;
using AHY.CQRS.WebApi.CQRS.Results;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace AHY.CQRS.WebApi.CQRS.Handlres
{
    public class GetStudentsQueryHandler : IRequestHandler<GetStudentsQuery, IEnumerable<GetStudentsQueryResult>>
    {
        private readonly StudentContext _context;

        public GetStudentsQueryHandler(StudentContext context)
        {
            _context = context;
        }

        //IEnumerable List yapısına göre daha az maliyetlidir. Çünkü IEnumerable bize sadece bir veri listesi verir. Bu veri listesi üzerine sorgulama yapamayız. Fakat List için biz bir list getirdikten sonra üzerinde sorgulama yapabilir ve List'e ait olan ekstra metodları kullanabilir.



        public async Task<IEnumerable<GetStudentsQueryResult>> Handle(GetStudentsQuery request, CancellationToken cancellationToken)
        {
            var students = _context.Set<Student>().AsNoTracking().Select(x => new GetStudentsQueryResult { Name = x.Name, Surname = x.Surname }).AsEnumerable();
            return  students;
        }

        //public IEnumerable<GetStudentsQueryResult> Handle(GetStudentsQuery query)
        //{
        //    var students = _context.Set<Student>().AsNoTracking().Select(x => new GetStudentsQueryResult { Name = x.Name, Surname = x.Surname }).AsEnumerable();
        //    return students;
        //}
    }
}
