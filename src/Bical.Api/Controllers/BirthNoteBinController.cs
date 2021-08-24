using System.Threading.Tasks;
using Bical.Api.Cqrs.Commands.BirthNotes;
using Bical.Api.Cqrs.Queries.BirthNotes;
using Microsoft.AspNetCore.Mvc;

namespace Bical.Api.Controllers
{
    public class BirthNoteBinController : ApiControllerBase
    {
        [HttpGet("api/bin")]
        public async Task<IActionResult> GetMarkedAsDeletedBirthNotes()
        {
            var query = new GetMarkedAsDeletedBirthNotesQuery();
            var notesInBin = await Mediator.Send(query);
            return Ok(notesInBin);
        }

        [HttpPost("clear")]
        public async Task<IActionResult> ClearBirthNotes()
        {
            var query = new ClearBirthNotesCommand();
            var count = await Mediator.Send(query);
            return Ok(new { Count = count });
        }

        [HttpGet("restore")]
        public async Task<IActionResult> RestoreBirthNotes()
        {
            var query = new RestoreBirthNotesCommand();
            var count = await Mediator.Send(query);
            return Ok(new { Count = count });
        }
    }
}