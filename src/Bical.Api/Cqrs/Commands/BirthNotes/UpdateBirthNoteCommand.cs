using System;
using MediatR;

namespace Bical.Api.Cqrs.Commands.BirthNotes
{
    public class UpdateBirthNoteCommand : IRequest<bool>
    {
        public ulong Id { get; set; }
        public string DisplayedName { get; set; }
        public DateTime? BirthDate { get; set; }
    }
}