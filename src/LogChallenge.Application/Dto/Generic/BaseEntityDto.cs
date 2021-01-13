using System;

namespace LogChallenge.Application.Dto.Generic
{
    public class BaseEntityDto : NotificationDto
    {
        public Guid Id { get; set; }

        public DateTime RegDate { get; set; }
        public DateTime UpdateDate { get; set; }
    }
}
