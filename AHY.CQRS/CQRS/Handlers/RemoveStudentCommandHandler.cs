using AHY.CQRS.Data;
using AHY.CQRS.WebApi.CQRS.Commands;
using MediatR;

namespace AHY.CQRS.WebApi.CQRS.Handlers
{
    public class RemoveStudentCommandHandler : IRequestHandler<RemoveStudentCommand>
    {
        private readonly StudentContext _context;

        public RemoveStudentCommandHandler(StudentContext context)
        {
            _context = context;
        }



        public async Task<Unit> Handle(RemoveStudentCommand request, CancellationToken cancellationToken)
        {
            var deletedEntity = _context.Students.FirstOrDefault(x => x.Id == request.Id);
            _context.Students.Remove(deletedEntity);
            await _context.SaveChangesAsync();
            return Unit.Value;
        }

        //public bool Handle(RemoveStudentCommand command)
        //{
        //    var deletedEntity = _context.Students.FirstOrDefault(x => x.Id == command.Id);
        //    if (deletedEntity != null)
        //    {
        //        _context.Students.Remove(deletedEntity);
        //        _context.SaveChanges();
        //        return true;
        //    }

        //    return false;
        //}
    }
}
