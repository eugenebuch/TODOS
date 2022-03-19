using System;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TODOS.Application.Cqrs.Notes.Commands.CreateNote;
using TODOS.Application.Cqrs.Notes.Commands.DeleteNote;
using TODOS.Application.Cqrs.Notes.Commands.UpdateNote;
using TODOS.Application.Cqrs.Notes.Queries.GetNoteDetails;
using TODOS.Application.Cqrs.Notes.Queries.GetNoteList;
using TODOS.WebApi.Models;

namespace TODOS.WebApi.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class NoteController : BaseController
    {
        private readonly IMapper _mapper;

        public NoteController(IMapper mapper) =>
            _mapper = mapper;

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<ActionResult<NoteListVm>> GetAll()
        {
            var query = new GetNoteListQuery();
            var vm = await Mediator.Send(query);
            return Ok(vm);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<ActionResult<NoteDetailsVm>> Get(Guid id)
        {
            var query = new GetNoteDetailsQuery { Id = id };
            var vm = await Mediator.Send(query);
            foreach (var elem in vm.Groups)
                elem.Notes = null;
            return Ok(vm);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<ActionResult<Guid>> Create([FromBody] CreateNoteDto createNoteDto)
        {
            var command = _mapper.Map<CreateNoteCommand>(createNoteDto);
            var noteId = await Mediator.Send(command);
            return Ok(noteId);
        }

        [HttpPut]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<ActionResult<Guid>> Update([FromBody] UpdateNoteDto updateNoteDto)
        {
            var command = _mapper.Map<UpdateNoteCommand>(updateNoteDto);
            var noteId = await Mediator.Send(command);
            return Ok(noteId);
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<ActionResult> Delete(Guid id)
        {
            var query = new DeleteNoteCommand { Id = id };
            await Mediator.Send(query);
            return NoContent();
        }
    }
}