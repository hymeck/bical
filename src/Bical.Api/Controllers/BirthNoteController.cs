using System.Threading.Tasks;
using Bical.Api.Cqrs.Commands.BirthNotes;
using Bical.Api.Cqrs.Queries.BirthNotes;
using Microsoft.AspNetCore.Mvc;

namespace Bical.Api.Controllers
{
    [Route("api/birthdays")]
    public class BirthNoteController : ApiControllerBase
    {
        [HttpPost("create")]
        public async Task<ActionResult<uint>> Create([FromBody] CreateBirthNoteCommand command)
        {
            var result = await Mediator.Send(command);
            return CreatedAtAction("GetBirth", new {id = result.BirthNoteId}, result);
        }
        
        [HttpGet("{id}")]
        public async Task<IActionResult> GetBirth(ushort id)
        {
            var query = new GetBirthNoteByIdQuery(id);
            var option = await Mediator.Send(query);
            return option.Match<IActionResult>(Ok, NotFound);
        }

        [HttpGet("")]
        public async Task<IActionResult> GetCalendar()
        {
            var query = new GetBirthCalendarQuery();
            var calendar = await Mediator.Send(query);
            return Ok(calendar);
        }
    }
}