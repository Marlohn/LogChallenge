using LogChallenge.Application.Dto.Generic;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LogChallenge.Application.Dto
{
    public class LogDto : BaseEntityDto
    {
        [Required(ErrorMessage = "The Host field is required.")]
        [MinLength(1)]
        [MaxLength(20)]
        [DisplayName("Host")]
        public string Host { get; set; }

        [MaxLength(50)]
        [DisplayName("Identity")]
        public string Identity { get; set; }

        [MaxLength(50)]
        [DisplayName("User")]
        public string User { get; set; }

        [Required(ErrorMessage = "The DateTime field is required.")]        
        [DataType(DataType.DateTime)]
        [DisplayName("DateTime")]
        public DateTime DateTime { get; set; }

        [Required(ErrorMessage = "The Request field is required.")]
        [MinLength(1)]
        [MaxLength(255)]
        [DisplayName("Request")]
        public string Request { get; set; }

        [Required(ErrorMessage = "The StatusCode field is required.")]
        [DisplayName("StatusCode")]
        [Range(100, 999)]
        public int StatusCode { get; set; }

        [DisplayName("Size")]
        [Range(0, Int32.MaxValue)]
        public int? Size { get; set; }

        [DisplayName("Referer")]
        [MaxLength(255)]
        public string Referer { get; set; }

        [DisplayName("UserAgent")]
        [MaxLength(255)]
        public string UserAgent { get; set; }

        [NotMapped]
        public List<NotificationDto> Notifications { get; set; }
    }
}
