using System;
using System.Threading;
using System.Threading.Tasks;
using Service.DTOs;

namespace Service.Contracts.RequestUrl
{
    public interface IRequestUrlService
    {
        Task<RequestUrlDto> GetShortUrl(Uri urlDto, CancellationToken cancellationToken);
        Task<RequestUrlDto> GetOriginalUrl(Uri urlDto, CancellationToken cancellationToken);
    }
}
