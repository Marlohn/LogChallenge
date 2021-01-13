using LogChallenge.Application.Dto.Generic;
using System;
using System.ComponentModel.DataAnnotations;

namespace LogChallenge.Application.Dto
{
    public class LogDto : BaseEntityDto
    {
        [Required]
        public string Host { get; set; }

        public string Identity { get; set; }

        public string User { get; set; }

        [Required]
        public DateTime DateTime { get; set; }

        [Required]
        public string Request { get; set; }

        [Required]
        public int StatusCode { get; set; }

        public int? Size { get; set; }

        public string Referer { get; set; }

        public string UserAgent { get; set; }
    }
}
