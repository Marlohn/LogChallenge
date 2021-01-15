using LogChallenge.Domain.Entities.Generic;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace LogChallenge.Domain.Entities
{
    public class Log : BaseEntity
    {
        public Log() 
        {
            Notifications = new List<Notification>();
        }

        public string Host { get; set; }
        public string Identity { get; set; }
        public string User { get; set; }
        public DateTime DateTime { get; set; }
        public string Request { get; set; }
        public int StatusCode { get; set; }
        public int? Size { get; set; }
        public string Referer { get; set; }
        public string UserAgent { get; set; }

        [NotMapped]
        public List<Notification> Notifications { get; set; }
    }
}
