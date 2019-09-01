using MediatR;

namespace Zip.Business
{
    public interface IZipRequest
    {
    }

    public class ZipRequest : IZipRequest, IRequest, INotification
    {
    }

    public class ZipRequest<T> : IZipRequest, IRequest<T>
    {
    }
}