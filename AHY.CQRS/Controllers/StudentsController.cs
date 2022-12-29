using AHY.CQRS.WebApi.CQRS.Commands;
using AHY.CQRS.WebApi.CQRS.Querys;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AHY.CQRS.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        //Kullanılmayan usingleri tek tek silmek yerine Analyze-Code/CleanUp-Run/Code CleanUp üzerinden proje bazından bunu yapabiliriz.

        #region Before The Mediator Pattern
        //private readonly GetStudentByIdQueryHandler _getStudentByIdQueryHandler;
        //private readonly GetStudentsQueryHandler _getStudentsQueryHandler;
        //private readonly CreateStudentCommandHandler _createStudentCommandHandler;
        //private readonly RemoveStudentCommandHandler _removeStudentCommandHandler;
        //private readonly UpdateStudentCommandHandler _updateStudentCommandHandler;
        //public StudentsController(GetStudentByIdQueryHandler getStudentByIdQueryHandler, GetStudentsQueryHandler getStudentsQueryHandler, CreateStudentCommandHandler createStudentCommandHandler, RemoveStudentCommandHandler removeStudentCommandHandler, UpdateStudentCommandHandler updateStudentCommandHandler)
        //{
        //    _getStudentByIdQueryHandler = getStudentByIdQueryHandler;
        //    _getStudentsQueryHandler = getStudentsQueryHandler;
        //    _createStudentCommandHandler = createStudentCommandHandler;
        //    _removeStudentCommandHandler = removeStudentCommandHandler;
        //    _updateStudentCommandHandler = updateStudentCommandHandler;
        //} 
        #endregion


        private readonly IMediator _mediator;

        public StudentsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetStudent(int id)
        {
            var result = await _mediator.Send(new GetStudentByIdQuery(id));
            return result != null ? Ok(result) : NotFound(id);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var response = await _mediator.Send(new GetStudentsQuery());
            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateStudentCommand command)
        {
            await _mediator.Send(command);
            return Created("",command);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _mediator.Send(new RemoveStudentCommand(id));
            return  NoContent();
        }

        [HttpPut]
        public async Task<IActionResult> Update(UpdateStudentCommand command)
        {
            await _mediator.Send(command);
            return NoContent();
        }

    }
}
