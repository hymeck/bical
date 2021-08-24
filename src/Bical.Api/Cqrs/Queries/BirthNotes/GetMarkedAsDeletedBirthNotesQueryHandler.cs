using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Bical.Api.Entities;
using Bical.Api.Persistence.Contexts;
using Bical.Api.Responses;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Bical.Api.Cqrs.Queries.BirthNotes
{
    public class GetMarkedAsDeletedBirthNotesQueryHandler : IRequestHandler<GetMarkedAsDeletedBirthNotesQuery, BirthNoteListDtoResponse>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public GetMarkedAsDeletedBirthNotesQueryHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<BirthNoteListDtoResponse> Handle(GetMarkedAsDeletedBirthNotesQuery request, CancellationToken cancellationToken)
        {
            var entities = await _context
                .Context.Set<BirthNote>()
                .Where(e => e.IsDeleted)
                .AsNoTracking()
                .ToListAsync(cancellationToken);
            
            var dtos = _mapper.Map<List<BirthNote>, List<BirthNoteDtoResponse>>(entities);

            return new BirthNoteListDtoResponse(dtos);
        }
    }
}