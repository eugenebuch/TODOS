using System;
using System.Collections.Generic;
using AutoMapper;
using TODOS.Application.Common.Mappings;
using TODOS.Domain;

namespace TODOS.Application.Cqrs.Notes.Queries.GetNoteDetails
{
    public class NoteDetailsVm : IMapWith<Note>
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Details { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime? EditDate { get; set; }
        public DateTime Deadline { get; set; }
        public IList<Group> Groups { get; set; }

        public void Mapping(Profile profile) => profile.CreateMap<Note, NoteDetailsVm>()
            .ForMember(dest => dest.Groups, opt => opt.MapFrom(src => src.Groups))
            .ReverseMap();
    }
}