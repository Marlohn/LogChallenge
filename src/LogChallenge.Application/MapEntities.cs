using AutoMapper;
using LogChallenge.Application.Dto;
using LogChallenge.Domain.Entities;

namespace LogChallenge.Application
{
    public class MapEntities : Profile
    {
        public MapEntities()
        {
            CreateMap<Log, LogDto>();
            CreateMap<LogDto, Log>();
        }
    }
}
