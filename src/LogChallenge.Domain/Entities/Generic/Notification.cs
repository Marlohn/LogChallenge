using System.ComponentModel.DataAnnotations.Schema;

namespace LogChallenge.Domain.Entities.Generic
{
    public class Notification
    {
        [NotMapped]
        public string PropertyName { get; set; }

        [NotMapped]
        public string Message { get; set; }
    }
}
