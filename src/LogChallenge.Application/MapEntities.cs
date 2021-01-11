using AutoMapper;
using LogChallenge.Application.Dto;
using LogChallenge.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
