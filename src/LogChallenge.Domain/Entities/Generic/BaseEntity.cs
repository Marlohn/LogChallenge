using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace LogChallenge.Domain.Entities.Generic
{
    public class BaseEntity : Notification
    {
        public Guid Id { get; set; }

        [NotMapped]
        public bool State { get; set; }
    }
}
