using LogChallenge.Domain.Entities;
using LogChallenge.Domain.Interfaces.Services.Generic;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LogChallenge.Domain.Interfaces.Services
{
    public interface ILogService : IBaseService<Log>
    {
        Task LogAdd(Log log);
        Task LogUpdate(Log log);
        Task<List<Log>> LogAddRange(List<Log> logList);
    }
}
