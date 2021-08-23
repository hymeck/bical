using System.Collections.Generic;
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
    public class GetBirthCalendarQueryHandler : IRequestHandler<GetBirthCalendarQuery, BirthNoteListDtoResponse>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public GetBirthCalendarQueryHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<BirthNoteListDtoResponse> Handle(GetBirthCalendarQuery request, CancellationToken cancellationToken)
        {
            // todo: dependency rule violation but i don't care
            var entities = await _context.Context
                .Set<BirthNote>()
                .FromSqlRaw("select * from birth order by dayofyear(dob)")
                .AsNoTracking()
                .ToListAsync(cancellationToken);
            var dtos = _mapper.Map<List<BirthNote>, List<BirthNoteDtoResponse>>(entities);
            return new BirthNoteListDtoResponse(dtos);
        }
    }
}