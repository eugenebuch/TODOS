using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using AutoMapper;
using TODOS.Application.Common.Mappings;
using TODOS.Application.Cqrs.Groups.Commands.CreateGroup;
using TODOS.Domain;

namespace TODOS.WebApi.Models
{
    public class CreateGroupDto : IMapWith<CreateGroupCommand>
    {
        [Required]
        public string Title { get; set; }
        public string Color { get; set; }
        public IList<Guid> Notes { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<CreateGroupDto, CreateGroupCommand>();
        }
    }
}