﻿using MediatR;

namespace AHY.CQRS.WebApi.CQRS.Commands
{
    public class RemoveStudentCommand :IRequest
    {
        public int Id { get; set; }

        public RemoveStudentCommand(int id)
        {
            Id = id;
        }
    }
}
