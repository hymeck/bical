using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Bical.Api.Persistence.Contexts;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Bical.Api.Cqrs.Commands.BirthNotes
{
    public class ClearBirthNotesCommandHandler : IRequestHandler<ClearBirthNotesCommand, int>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public ClearBirthNotesCommandHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        
        public async Task<int> Handle(ClearBirthNotesCommand request, CancellationToken cancellationToken)
        {
            await using var connection = _context.Context.Database.GetDbConnection();
            await connection.OpenAsync(cancellationToken);
            await using var cmd = connection.CreateCommand();
            cmd.CommandText = "delete from birth where deleted = 1";
            return await cmd.ExecuteNonQueryAsync(cancellationToken);
        }
    }
}