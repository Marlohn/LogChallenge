using LogChallenge.Domain.Entities;
using LogChallenge.Domain.Interfaces.Repositories.Generic;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LogChallenge.Domain.Interfaces.Repositories
{
    public interface ILogRepository : IBaseRepository<Log>
    {
        Task AddLog(Log log);
        Task UpdateLog(Log log);
        Task<List<Log>> LogAddRange(List<Log> logList);
    }
}
