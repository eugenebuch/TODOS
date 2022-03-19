using System;
using System.Collections.Generic;

namespace TODOS.Domain
{
    public class Group
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Color { get; set; }
        public ICollection<Note> Notes { get; set; }
    }
}