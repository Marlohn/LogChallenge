using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace LogChallenge.Domain.Entities.Generic
{
    public class Notification
    {
        public Notification()
        {
            notifications = new List<Notification>();
        }

        [NotMapped]
        public string PropertyName { get; set; }

        [NotMapped]
        public string mensage { get; set; }

        [NotMapped]
        public List<Notification> notifications { get; set; }

        public bool isString(string value, string propertyName)
        {
            if (string.IsNullOrEmpty(value) || string.IsNullOrEmpty(propertyName))
            {
                notifications.Add(new Notification
                {
                    mensage = "Required field",
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
                notifications.Add(new Notification
                {
                    mensage = "Value must be bigger than 0",
                    PropertyName = propertyName
                });
                return false;
            }
            return true;
        }
    }
}
