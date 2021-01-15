using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace LogChallenge.Domain.Entities.Generic
{
    public class BaseEntity
    {
        public Guid Id { get; set; }

        public DateTime RegDate { get; set; }

        public DateTime UpdateDate { get; set; }

        [NotMapped]
        public bool State { get; set; }
    }
}
