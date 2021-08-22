using System;
using Bical.Api.Responses;
using MediatR;

namespace Bical.Api.Cqrs.Commands.BirthNotes
{
    public class CreateBirthNoteCommand : IRequest<BirthNoteDtoResponse>
    {
        public string DisplayedName { get; set; }
        public DateTime BirthDate { get; set; }
    }
}