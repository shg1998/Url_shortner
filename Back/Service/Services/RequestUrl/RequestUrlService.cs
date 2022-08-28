using System;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Common;
using Common.Utilities;
using Data;
using Service.Contracts.RequestUrl;
using Service.DTOs;

namespace Service.Services.RequestUrl
{
    public class RequestUrlService : IScopedDependency, IRequestUrlService
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly IMapper _mapper;

        public RequestUrlService(ApplicationDbContext dbContext,IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }


        public async Task<SentRequestUrlDto> GetShortUrl(ReceivedRequestUtlDto urlDto, CancellationToken cancellationToken)
        {
            var uniqueKey = UniqueKeyGenerator.GenerateAddress();
            var shortUrl = new Uri($"http://localhost:44384/{uniqueKey}");
            var finalUrl = new SentRequestUrlDto
            {
                OriginalUrl = urlDto.OriginalUrl,
                FinalUrl = shortUrl
            };

            var requestUrl = _mapper.Map<Entities.RequestUrl>(finalUrl);
            await _dbContext.Set<Entities.RequestUrl>().AddAsync(requestUrl, cancellationToken);
            await _dbContext.SaveChangesAsync(cancellationToken);
            return finalUrl;
        }
    }
}
