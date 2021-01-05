using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogChallenge.Entities.Notifications
{
    public class Notifies
    {
        public Notifies()
        {
            notifications = new List<Notifies>();
        }

        [NotMapped]
        public string PropertyName { get; set; }

        [NotMapped]
        public string mensage { get; set; }

        [NotMapped]
        public List<Notifies> notifications { get; set; }

        public bool ValidadeStringProperty(string value, string propertyName)
        {
            if (string.IsNullOrEmpty(value) || string.IsNullOrEmpty(propertyName))
            {
                notifications.Add(new Notifies
                {
                    mensage = "Required field",
                    PropertyName = propertyName
                });

                return false;
            }
            return true;
        }
    }
}
