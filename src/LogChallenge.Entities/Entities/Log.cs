using LogChallenge.Entities.Notifications;
using System;

namespace LogChallenge.Domain.Models
{
    public class Log : BaseEntity
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
