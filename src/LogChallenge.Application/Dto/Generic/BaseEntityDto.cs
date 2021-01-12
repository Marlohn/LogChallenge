using System;

namespace LogChallenge.Application.Dto.Generic
{
    public class BaseEntityDto : NotificationDto
    {
        public Guid Id { get; set; }
    }
}
