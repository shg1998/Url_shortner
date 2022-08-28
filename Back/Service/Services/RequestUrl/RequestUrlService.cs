using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Common;
using Common.Exceptions;
using Common.Utilities;
using Data;
using Microsoft.EntityFrameworkCore;
using Service.Contracts.RequestUrl;
using Service.DTOs;

namespace Service.Services.RequestUrl
{
    public class RequestUrlService : IScopedDependency, IRequestUrlService
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly IMapper _mapper;

        public RequestUrlService(ApplicationDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }


        public async Task<RequestUrlDto> GetShortUrl(Uri urlDto, CancellationToken cancellationToken)
        {
            var uniqueKey = UniqueKeyGenerator.GenerateAddress();
            var shortUrl = new Uri($"http://localhost:44384/{uniqueKey}");
            var finalUrl = new RequestUrlDto
            {
                OriginalUrl = urlDto,
                FinalUrl = shortUrl
            };

            var requestUrl = _mapper.Map<Entities.RequestUrl>(finalUrl);
            await _dbContext.Set<Entities.RequestUrl>().AddAsync(requestUrl, cancellationToken);
            await _dbContext.SaveChangesAsync(cancellationToken);
            return finalUrl;
        }

        public async Task<RequestUrlDto> GetOriginalUrl(Uri urlDto, CancellationToken cancellationToken)
        {
            var selectedLink = await _dbContext.Set<Entities.RequestUrl>()
                .FirstOrDefaultAsync(s => s.FinalUrl.Equals(urlDto), cancellationToken);

            if (selectedLink == null)
                throw new NotFoundException("یافت نشد");
            selectedLink.ViewCount += 1;
            await _dbContext.SaveChangesAsync(cancellationToken);
            var requestDto = _mapper.Map<RequestUrlDto>(selectedLink);
            requestDto.ViewCount = selectedLink.ViewCount;
            return  requestDto;
        }
    }
}
