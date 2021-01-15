using System;
using System.ComponentModel.DataAnnotations;

namespace LogChallenge.Application.Dto.Generic
{
    public class BaseEntityDto
    {
        [Key]
        public Guid Id { get; set; }

        public DateTime RegDate { get; set; }
        public DateTime UpdateDate { get; set; }
    }
}
