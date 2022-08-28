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
using WebFrameworks.Api;
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

        [HttpGet("get-url-short-link")]
        public async Task<ActionResult<RequestUrlDto>> GetUrlShortLink(string url, CancellationToken cancellationToken)
        {
            var uri = new Uri(url);
            var urlReq = await _requestUrlService.GetShortUrl(uri, cancellationToken);
            return Ok(urlReq);
        }

        [HttpGet("get-url-orig-link")]
        public async Task<ApiResult<RequestUrlDto>> GetOriginalLink(string url, CancellationToken cancellationToken)
        {
            var uri = new Uri(url);
            var urlReq = await _requestUrlService.GetOriginalUrl(uri, cancellationToken);
            return urlReq;
        }

    }
}
