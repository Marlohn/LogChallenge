using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace LogChallenge.Domain.Entities.Generic
{
    public class Notification
    {
        public Notification()
        {
            Notifications = new List<Notification>();
        }

        [NotMapped]
        public string PropertyName { get; set; }

        [NotMapped]
        public string Message { get; set; }

        [NotMapped]
        public List<Notification> Notifications { get; set; }

        public bool isString(string value, string propertyName)
        {
            if (string.IsNullOrEmpty(value) || string.IsNullOrEmpty(propertyName))
            {
                Notifications.Add(new Notification
                {
                    Message = "Required field",
                    PropertyName = propertyName
                });
                return false;
            }
            return true;
        }

        public bool isPositiveInteger(int value, string propertyName)
        {
            if (value < 1 || string.IsNullOrEmpty(propertyName))
            {
                Notifications.Add(new Notification
                {
                    Message = "Value must be bigger than 0",
                    PropertyName = propertyName
                });
                return false;
            }
            return true;
        }
    }
}
