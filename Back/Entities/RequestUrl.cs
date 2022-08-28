using System;
using System.ComponentModel.DataAnnotations;
using Entities.Common;

namespace Entities
{
    public class RequestUrl : BaseEntity
    {
        [Required]
        [Display(Name="Main Address ")]
        public Uri OriginalUrl { get; set; }

        [Display(Name="Created Short Address")]
        [MaxLength(350)]
        public Uri FinalUrl { get; set; }

        public int ViewCount { get; set; }
    }
}
