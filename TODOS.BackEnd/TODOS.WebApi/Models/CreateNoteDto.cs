using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using AutoMapper;
using TODOS.Application.Common.Mappings;
using TODOS.Application.Cqrs.Notes.Commands.CreateNote;
using TODOS.Domain;

namespace TODOS.WebApi.Models
{
    public class CreateNoteDto : IMapWith<CreateNoteCommand>
    {
        [Required]
        public string Title { get; set; }
        public string Details { get; set; }
        public DateTime Deadline { get; set; }
        public IList<Guid> Groups { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<CreateNoteDto, CreateNoteCommand>();
        }
    }
}