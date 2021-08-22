using System;
using Bical.Api.Responses;
using MediatR;

namespace Bical.Api.Cqrs.Commands.BirthNotes
{
    public class CreateBirthdayNoteCommand : IRequest<BirthNoteDtoResponse>
    {
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public DateTime BirthDate { get; set; }
    }
}