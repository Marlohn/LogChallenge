using AutoMapper;
using LogChallenge.Application.Dto;
using LogChallenge.Application.Interfaces;
using LogChallenge.Application.Services.Generic;
using LogChallenge.Domain.Entities;
using LogChallenge.Domain.Interfaces.Services;
using LogChallenge.Domain.Services.Generic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogChallenge.Application.Services
{
    public class LogApplicationService : BaseApplicationService<Log, LogDto>, ILogApplication
    {
        protected readonly ILogService _LogService;
        protected readonly IMapper _iMapper;

        public LogApplicationService(IMapper iMapper, ILogService LogService) : base(iMapper, LogService)    
        {
            _iMapper = iMapper;
            _LogService = LogService;
        }

        public async Task UpdateLog(LogDto log)
        {
            await _LogService.UpdateLog(_iMapper.Map<Log>(log));
        }

        public async Task AddLog(LogDto log)
        {
            await _LogService.AddLog(_iMapper.Map<Log>(log));
        }

    }
}
