using System.Threading;
using System.Threading.Tasks;
using Bical.Api.Persistence.Contexts;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Bical.Api.Cqrs.Commands.BirthNotes
{
    public class RestoreBirthNotesCommandHandler : IRequestHandler<RestoreBirthNotesCommand, int>
    {
        private readonly IApplicationDbContext _context;

        public RestoreBirthNotesCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<int> Handle(RestoreBirthNotesCommand request, CancellationToken cancellationToken)
        {
            await using var connection = _context.Context.Database.GetDbConnection();
            await connection.OpenAsync(cancellationToken);
            await using var cmd = connection.CreateCommand();
            cmd.CommandText = "update birth set deleted = 0 where deleted = 1";
            return await cmd.ExecuteNonQueryAsync(cancellationToken);
        }
    }
}