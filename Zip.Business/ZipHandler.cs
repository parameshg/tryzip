using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;

namespace Zip.Business
{
    public interface IZipHandler
    {
    }

    public class ZipHandler : IZipHandler
    {
        protected IMediator Mediator { get; private set; }

        public ZipHandler(IMediator mediator)
        {
            Mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }
    }

    public abstract class ZipHandler<T> : INotificationHandler<T>, IZipHandler where T : INotification
    {
        protected IMediator Mediator { get; private set; }

        public ZipHandler(IMediator mediator)
        {
            Mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        protected abstract Task Execute(T request, CancellationToken token);

        async Task INotificationHandler<T>.Handle(T request, CancellationToken token)
        {
            await Execute(request, token);
        }
    }

    public abstract class ZipHandler<TRequest, TResponse> : IRequestHandler<TRequest, TResponse>, IZipHandler where TRequest : IRequest<TResponse>
    {
        protected IMediator Mediator { get; private set; }

        public ZipHandler(IMediator mediator)
        {
            Mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        protected abstract Task<TResponse> Execute(TRequest request, CancellationToken token);

        public async Task<TResponse> Handle(TRequest request, CancellationToken token)
        {
            return await Execute(request, token);
        }
    }
}