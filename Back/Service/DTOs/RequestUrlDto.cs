using Entities;
using Service.WebFramework.Api;
using System;
using System.ComponentModel.DataAnnotations;

namespace Service.DTOs
{
    public class RequestUrlDto : BaseDto<RequestUrlDto, RequestUrl>
    {
        [Required]
        [Display(Name = "Main Address ")]
        public Uri OriginalUrl { get; set; }

        [Display(Name = "Created Short Address")]
        [MaxLength(350)]
        public Uri FinalUrl { get; set; }

        public int ViewCount { get; set; }
    }
}
