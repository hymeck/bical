using System;
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
    public class GetNearestBirthdaysQueryHandler : IRequestHandler<GetNearestBirthdaysQuery, BirthNoteListDtoResponse>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public GetNearestBirthdaysQueryHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        
        public async Task<BirthNoteListDtoResponse> Handle(GetNearestBirthdaysQuery request, CancellationToken cancellationToken)
        {
            var now = DateTime.UtcNow; // todo: clutch; edge values
            var edge = now.Add(TimeSpan.FromDays(request.Days));
            var nowStr = now.ToString("yyyy-MM-dd");
            var edgeStr = edge.ToString("yyyy-MM-dd");
            
            // todo: again
            var entities = await _context.Context
                .Set<BirthNote>()
                .FromSqlRaw("select * from birth where dayofyear(dob) between dayofyear({0}) and dayofyear({1}) order by dayofyear(dob)", nowStr, edgeStr)
                .AsNoTracking()
                .ToListAsync(cancellationToken);

            var dtos = _mapper.Map<List<BirthNote>, List<BirthNoteDtoResponse>>(entities);
            return new BirthNoteListDtoResponse(dtos);
        }
    }
}