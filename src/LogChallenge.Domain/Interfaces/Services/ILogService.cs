using LogChallenge.Domain.Entities;
using LogChallenge.Domain.Interfaces.Services.Generic;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LogChallenge.Domain.Interfaces.Services
{
    public interface ILogService : IBaseService<Log>
    {
        Task<Log> LogAdd(Log log);
        Task<Log> LogUpdate(Log log);
        Task<List<Log>> LogAddRange(List<Log> logList);
        Task<List<Log>> ConvertFileToLog(IFormFile file);
    }
}
