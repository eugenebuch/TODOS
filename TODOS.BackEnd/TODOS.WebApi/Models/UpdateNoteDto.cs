using System;
using System.Collections.Generic;
using AutoMapper;
using TODOS.Application.Common.Mappings;
using TODOS.Application.Cqrs.Notes.Commands.UpdateNote;
using TODOS.Domain;

namespace TODOS.WebApi.Models
{
    public class UpdateNoteDto : IMapWith<UpdateNoteCommand>
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Details { get; set; }
        public DateTime Deadline { get; set; }
        public IList<Guid> Groups { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<UpdateNoteDto, UpdateNoteCommand>();
        }
    }
}