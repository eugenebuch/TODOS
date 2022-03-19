using System;
using MediatR;

namespace TODOS.Application.Cqrs.Groups.Queries.GetGroupList
{
    public class GetGroupListQuery : IRequest<GroupListVm> 
    {
    }
}