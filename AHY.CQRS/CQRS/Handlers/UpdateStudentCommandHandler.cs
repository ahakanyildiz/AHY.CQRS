using AHY.CQRS.Data;
using AHY.CQRS.WebApi.CQRS.Commands;
using MediatR;

namespace AHY.CQRS.WebApi.CQRS.Handlers
{
    public class UpdateStudentCommandHandler : IRequestHandler<UpdateStudentCommand>
    {
        private readonly StudentContext _context;

        public UpdateStudentCommandHandler(StudentContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(UpdateStudentCommand request, CancellationToken cancellationToken)
        {
            var unchangedStudent = _context.Students.Find(request.Id);

            _context.Students.Entry(unchangedStudent).CurrentValues.SetValues(new Student
            {
                Age = request.Age,
                Id = request.Id,
                Name = request.Name,
                Surname = request.Surname,
            });

            await _context.SaveChangesAsync();
            return Unit.Value;
        }



        //public bool Handle(UpdateStudentCommand command)
        //{
        //    var unchangedStudent = _context.Students.Find(command.Id);
        //    if (unchangedStudent != null)
        //    {
        //        _context.Students.Entry(unchangedStudent).CurrentValues.SetValues(new Student
        //        {
        //            Age = command.Age,
        //            Id = command.Id,
        //            Name = command.Name,
        //            Surname = command.Surname,
        //        });
        //        _context.SaveChanges();
        //        return true;
        //    }

        //    return false;
        //}
    }
}
