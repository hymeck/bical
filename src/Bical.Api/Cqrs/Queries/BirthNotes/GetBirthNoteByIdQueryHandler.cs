using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Bical.Api.Entities;
using Bical.Api.Persistence.Contexts;
using Bical.Api.Responses;
using LanguageExt;
using LanguageExt.SomeHelp;
using MediatR;

namespace Bical.Api.Cqrs.Queries.BirthNotes
{
    public class
        GetBirthNoteByIdQueryHandler : IRequestHandler<GetBirthNoteByIdQuery, Option<BirthNoteDtoResponse>>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public GetBirthNoteByIdQueryHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<Option<BirthNoteDtoResponse>> Handle(GetBirthNoteByIdQuery request,
            CancellationToken cancellationToken)
        {
            var entity = await _context.Context.Set<BirthNote>()
                .FindAsync(new object[] {request.Id}, cancellationToken);
            return entity != null
                ? _mapper.Map<BirthNote, BirthNoteDtoResponse>(entity).ToSome()
                : Option<BirthNoteDtoResponse>.None;
        }
    }
}