using System;
using System.ComponentModel.DataAnnotations;
using Entities;
using Service.WebFramework.Api;

namespace Service.DTOs
{
    public class SentRequestUrlDto : BaseDto<SentRequestUrlDto, RequestUrl>
    {
        [Required]
        [Display(Name = "Main Address ")]
        public Uri OriginalUrl { get; set; }

        [Display(Name = "Created Short Address")]
        [MaxLength(350)]
        public Uri FinalUrl { get; set; }
    }
}
