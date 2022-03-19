using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Serilog;

namespace TODOS.Application.Common.Behaviors
{
    public class LoggingBehavior<TRequest, TResponse>
        : IPipelineBehavior<TRequest, TResponse> where TRequest
        : IRequest<TResponse>
    {

        public async Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken, RequestHandlerDelegate<TResponse> next)
        {
            var requestName = typeof(TRequest).Name;

            Log.Information("Todo's Request: {Name} {@UserId} {@Request}", requestName, request);

            var response = await next();

            return response;
        }
    }
}