using System;

namespace TODOS.Application.Interfaces
{
    public interface ICurrentUserService
    {
        Guid UserId { get; }
    }
}