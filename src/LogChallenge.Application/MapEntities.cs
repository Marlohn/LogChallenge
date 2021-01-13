using AutoMapper;
using LogChallenge.Application.Dto;
using LogChallenge.Application.Dto.Generic;
using LogChallenge.Domain.Entities;
using LogChallenge.Domain.Entities.Generic;

namespace LogChallenge.Application
{
    public class MapEntities : Profile
    {
        public MapEntities()
        {
            CreateMap<Log, LogDto>();
            CreateMap<LogDto, Log>();
            CreateMap<BaseEntity, BaseEntityDto>();
            CreateMap<BaseEntityDto, BaseEntity>();
            CreateMap<Notification, NotificationDto>();
            CreateMap<NotificationDto, Notification>();
        }
    }
}
