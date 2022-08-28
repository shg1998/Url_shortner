using System.Threading;
using System.Threading.Tasks;
using Service.DTOs;

namespace Service.Contracts.RequestUrl
{
    public interface IRequestUrlService
    {
        Task<SentRequestUrlDto> GetShortUrl(ReceivedRequestUtlDto urlDto, CancellationToken cancellationToken);
    }
}
