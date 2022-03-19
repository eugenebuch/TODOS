using System;
using System.Collections.Generic;
using AutoMapper;
using TODOS.Application.Common.Mappings;
using TODOS.Application.Cqrs.Groups.Commands.UpdateGroup;

namespace TODOS.WebApi.Models
{
    public class UpdateGroupDto : IMapWith<UpdateGroupCommand>
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Color { get; set; }
        public IList<Guid> Notes { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<UpdateGroupDto, UpdateGroupCommand>();
        }
    }
}