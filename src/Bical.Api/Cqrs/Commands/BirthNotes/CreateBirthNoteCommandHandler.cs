using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Bical.Api.Entities;
using Bical.Api.Persistence.Contexts;
using Bical.Api.Responses;
using MediatR;

namespace Bical.Api.Cqrs.Commands.BirthNotes
{
    public class CreateBirthNoteCommandHandler : IRequestHandler<CreateBirthNoteCommand, BirthNoteDtoResponse>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public CreateBirthNoteCommandHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<BirthNoteDtoResponse> Handle(CreateBirthNoteCommand request, CancellationToken cancellationToken)
        {
            var entity = _mapper.Map<CreateBirthNoteCommand, BirthNote>(request);
            _context.Context.Set<BirthNote>().Add(entity);
            await _context.SaveChangesAsync(cancellationToken);
            return _mapper.Map<BirthNote, BirthNoteDtoResponse>(entity);
        }
    }
}