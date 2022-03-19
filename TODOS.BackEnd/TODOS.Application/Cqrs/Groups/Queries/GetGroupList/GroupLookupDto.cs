﻿using System;
using System.Collections.Generic;
using AutoMapper;
using TODOS.Application.Common.Mappings;
using TODOS.Domain;

namespace TODOS.Application.Cqrs.Groups.Queries.GetGroupList
{
    public class GroupLookupDto : IMapWith<Group>
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Color { get; set; }
        public IList<Note> Notes { get; set; }

        public void Mapping(Profile profile) =>
            profile.CreateMap<Group, GroupLookupDto>();
    }
}