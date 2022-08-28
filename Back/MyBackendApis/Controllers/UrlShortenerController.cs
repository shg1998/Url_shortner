using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Common.Utilities;
using Service.Contracts.RequestUrl;
using Service.DTOs;
using WebFrameworks.Filters;

namespace MyBackendApis.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [ApiResultFilter]
    public class UrlShortenerController : ControllerBase
    {
        private readonly IRequestUrlService _requestUrlService;
        private readonly IMapper _mapper;

        public UrlShortenerController(IRequestUrlService requestUrlService,IMapper mapper)
        {
            _requestUrlService = requestUrlService;
            _mapper = mapper;
        }

        [HttpPost("get-url-short-link")]
        public async Task<SentRequestUrlDto> GetUrlShortLink([FromBody] ReceivedRequestUtlDto urlDto, CancellationToken cancellationToken)
        {
            var urlReq = await _requestUrlService.GetShortUrl(urlDto, cancellationToken);
            return urlReq;
        }
    }
}
