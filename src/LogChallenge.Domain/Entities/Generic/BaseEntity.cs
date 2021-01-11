using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogChallenge.Domain.Entities.Generic
{
    public class BaseEntity : Notification
    {
        public Guid Id { get; set; }

        [NotMapped]
        public bool State { get; set; }
    }
}
