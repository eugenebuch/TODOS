using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TODOS.Application.Cqrs.Groups.Commands.CreateGroup;
using TODOS.Application.Cqrs.Groups.Commands.DeleteGroup;
using TODOS.Application.Cqrs.Groups.Commands.UpdateGroup;
using TODOS.Application.Cqrs.Groups.Queries.GetGroupDetails;
using TODOS.Application.Cqrs.Groups.Queries.GetGroupList;
using TODOS.WebApi.Models;

namespace TODOS.WebApi.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class GroupController : BaseController
    {
        private readonly IMapper _mapper;

        public GroupController(IMapper mapper) =>
            _mapper = mapper;

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<ActionResult<GroupListVm>> GetAll()
        {
            var query = new GetGroupListQuery();
            var vm = await Mediator.Send(query);
            return Ok(vm);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<ActionResult<GroupDetailsVm>> Get(Guid id)
        {
            var query = new GetGroupDetailsQuery { Id = id };
            var vm = await Mediator.Send(query);
            foreach (var elem in vm.Notes)
                elem.Groups = null;
            return Ok(vm);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<ActionResult<Guid>> Create([FromBody] CreateGroupDto createGroupDto)
        {
            var command = _mapper.Map<CreateGroupCommand>(createGroupDto);
            var GroupId = await Mediator.Send(command);
            return Ok(GroupId);
        }

        [HttpPut]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<ActionResult<Guid>> Update([FromBody] UpdateGroupDto updateGroupDto)
        {
            var command = _mapper.Map<UpdateGroupCommand>(updateGroupDto);
            var GroupId = await Mediator.Send(command);
            return Ok(GroupId);
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<ActionResult> Delete(Guid id)
        {
            var query = new DeleteGroupCommand { Id = id };
            await Mediator.Send(query);
            return NoContent();
        }
    }
}