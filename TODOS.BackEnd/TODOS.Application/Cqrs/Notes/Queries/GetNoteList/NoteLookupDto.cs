using System;
using System.Collections;
using System.Collections.Generic;
using AutoMapper;
using TODOS.Application.Common.Mappings;
using TODOS.Domain;

namespace TODOS.Application.Cqrs.Notes.Queries.GetNoteList
{
    public class NoteLookupDto : IMapWith<Note>
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Details { get; set; }
        public DateTime Deadline { get; set; }
        public IList<Group> Groups { get; set; }

        public void Mapping(Profile profile) =>
            profile.CreateMap<Note, NoteLookupDto>();
    }
}