using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Bical.Api.Entities;
using Bical.Api.Persistence.Contexts;
using MediatR;

namespace Bical.Api.Cqrs.Commands.BirthNotes
{
    public class UpdateBirthNoteCommandHandler : IRequestHandler<UpdateBirthNoteCommand, bool>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public UpdateBirthNoteCommandHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        
        public async Task<bool> Handle(UpdateBirthNoteCommand request, CancellationToken cancellationToken)
        {
            // todo: double access to db
            var dbEntity = await _context.Context.Set<BirthNote>().FindAsync(new object[] {request.Id}, cancellationToken);
            return await TryUpdate(dbEntity, request, cancellationToken);
        }

        private async Task<bool> TryUpdate(BirthNote dbEntity, UpdateBirthNoteCommand request, CancellationToken cancellationToken)
        {
            if (dbEntity == null) 
                return false;
            
            await UpdateBirthNoteOnDb(dbEntity, request, cancellationToken);
            return true;
        }

        private async Task UpdateBirthNoteOnDb(BirthNote dbEntity, UpdateBirthNoteCommand request,
            CancellationToken cancellationToken)
        {
            MutateBirthNote(dbEntity, request);
            _context.Context.Set<BirthNote>().Update(dbEntity);
            await _context.SaveChangesAsync(cancellationToken);
        }

        private static void MutateBirthNote(BirthNote note, UpdateBirthNoteCommand request)
        {
            note.DisplayedName = request.DisplayedName;
            if (request.BirthDate.HasValue)
                note.BirthDate = request.BirthDate.Value;
        }
    }
}