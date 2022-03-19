using System.Collections.Generic;

namespace TODOS.Application.Cqrs.Groups.Queries.GetGroupList
{
    public class GroupListVm
    {
        public IList<GroupLookupDto> Groups { get; set; }
    }
}