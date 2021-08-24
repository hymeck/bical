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
        public async Task<IActionResult> GetBirth(ulong id)
        {
            var query = new GetBirthNoteByIdQuery(id);
            var option = await Mediator.Send(query);
            return option.Match<IActionResult>(Ok, NotFound);
        }

        [HttpGet("calendar")]
        public async Task<IActionResult> GetCalendar()
        {
            var query = new GetBirthCalendarQuery();
            var calendar = await Mediator.Send(query);
            return Ok(calendar);
        }
        
        [HttpGet("")]
        public async Task<IActionResult> GetNearestBirthdays([FromQuery] int days)
        {
            var query = new GetNearestBirthdaysQuery(days);
            var calendar = await Mediator.Send(query);
            return Ok(calendar);
        }

        [HttpPut("{id}")]
        [HttpPost("{id}")]
        public async Task<IActionResult> UpdateBirthNote(ulong id, [FromBody] UpdateBirthNoteCommand command)
        {
            if (id != command.Id)
                return BadRequest();
            var updated = await Mediator.Send(command);
            return updated ? NoContent() : NotFound();
        }
    }
}