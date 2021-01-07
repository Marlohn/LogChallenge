using LogChallenge.Application.Dto.Generic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogChallenge.Application.Dto
{
    public class LogDto : BaseEntityDto
    {
        public string Host { get; set; }
        public string Identity { get; set; }
        public string User { get; set; }
        public DateTime DateTime { get; set; }
        public string Request { get; set; }
        public int StatusCode { get; set; }
        public int? Size { get; set; }
        public string Referer { get; set; }
        public string UserAgent { get; set; }
    }
}
