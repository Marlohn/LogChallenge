using LogChallenge.Application.Dto;
using LogChallenge.Application.Interfaces.Generic;
using LogChallenge.Domain.Entities;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LogChallenge.Application.Interfaces
{
    public interface ILogApplication : IBaseApplication<Log, LogDto>
    {
        Task<LogDto> LogAdd(LogDto log);
        Task<LogDto> LogUpdate(LogDto log);
        Task<List<LogDto>> ConvertFileToLog(IFormFile file);
        Task<List<LogDto>> LogAddRange(List<LogDto> logList);
    }
}