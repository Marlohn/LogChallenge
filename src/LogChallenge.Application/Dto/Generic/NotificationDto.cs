using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace LogChallenge.Application.Dto.Generic
{
    public class NotificationDto
    {
        [NotMapped]
        public string PropertyName { get; set; }

        [NotMapped]
        public string Message { get; set; }
    }
}