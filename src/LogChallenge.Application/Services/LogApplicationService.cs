using AutoMapper;
using LogChallenge.Application.Dto;
using LogChallenge.Application.Interfaces;
using LogChallenge.Application.Services.Generic;
using LogChallenge.Domain.Entities;
using LogChallenge.Domain.Interfaces.Services;
using System.Threading.Tasks;

namespace LogChallenge.Application.Services
{
    public class LogApplicationService : BaseApplicationService<Log, LogDto>, ILogApplication
    {
        protected readonly ILogService _logService;
        protected readonly IMapper _mapper;

        public LogApplicationService(IMapper mapper, ILogService logService) : base(mapper, logService)
        {
            _mapper = mapper;
            _logService = logService;
        }

        public async Task UpdateLog(LogDto log)
        {
            await _logService.UpdateLog(_mapper.Map<Log>(log));
        }

        public async Task AddLog(LogDto log)
        {
            await _logService.AddLog(_mapper.Map<Log>(log));
        }

    }
}
