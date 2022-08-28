using System;
using System.ComponentModel.DataAnnotations;
using Entities;
using Service.WebFramework.Api;

namespace Service.DTOs
{
    public class ReceivedRequestUrlDto : BaseDto<ReceivedRequestUrlDto, RequestUrl>
    {
        [Required]
        [Display(Name = "Main Address ")]
        public Uri OriginalUrl { get; set; }
    }
}
