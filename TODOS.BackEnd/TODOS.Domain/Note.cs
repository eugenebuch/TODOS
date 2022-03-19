using System;
using System.Collections.Generic;

namespace TODOS.Domain
{
    public class Note
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Details { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime? EditDate { get; set; }
        public DateTime Deadline { get; set; }
        public ICollection<Group> Groups { get; set; }
    }
}