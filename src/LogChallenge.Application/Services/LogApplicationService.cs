using AutoMapper;
using LogChallenge.Application.Dto;
using LogChallenge.Application.Interfaces;
using LogChallenge.Application.Services.Generic;
using LogChallenge.Domain.Entities;
using LogChallenge.Domain.Interfaces.Services;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
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

        public async Task<LogDto> LogUpdate(LogDto logDto)
        {
            var log = await _logService.LogUpdate(_mapper.Map<Log>(logDto));
            return _mapper.Map<LogDto>(log);
        }

        public async Task<LogDto> LogAdd(LogDto logDto)
        {
            var log = await _logService.LogAdd(_mapper.Map<Log>(logDto));
            return _mapper.Map<LogDto>(log);
        }

        public async Task<List<LogDto>> LogAddRange(List<LogDto> logDtoList)
        {
            return _mapper.Map<List<LogDto>>(await _logService.LogAddRange(_mapper.Map<List<Log>>(logDtoList)));
        }

        public async Task<List<LogDto>> ConvertFileToLog(IFormFile file)
        {
            return _mapper.Map<List<LogDto>>(await _logService.ConvertFileToLog(file));
        }

    }
}
