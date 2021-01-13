﻿using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace LogChallenge.Application.Dto.Generic
{
    public class NotificationDto
    {
        public NotificationDto()
        {
            Notifications = new List<NotificationDto>();
        }

        [NotMapped]
        public string PropertyName { get; set; }

        [NotMapped]
        public string Message { get; set; }

        [NotMapped]
        public List<NotificationDto> Notifications { get; set; }

        //public bool isString(string value, string propertyName)
        //{
        //    if (string.IsNullOrEmpty(value) || string.IsNullOrEmpty(propertyName))
        //    {
        //        notifications.Add(new NotificationDto
        //        {
        //            message = "Required field",
        //            PropertyName = propertyName
        //        });
        //        return false;
        //    }
        //    return true;
        //}

        //public bool isPositiveInteger(int value, string propertyName)
        //{
        //    if (value < 1 || string.IsNullOrEmpty(propertyName))
        //    {
        //        notifications.Add(new NotificationDto
        //        {
        //            message = "Value must be bigger than 0",
        //            PropertyName = propertyName
        //        });
        //        return false;
        //    }
        //    return true;
        //}
    }
}
