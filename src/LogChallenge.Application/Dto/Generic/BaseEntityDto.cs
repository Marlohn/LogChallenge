﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogChallenge.Application.Dto.Generic
{
    public class BaseEntityDto : NotificationDto
    {
        public Guid Id { get; set; }
    }
}
