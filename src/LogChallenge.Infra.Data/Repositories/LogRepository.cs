using LogChallenge.Domain.Entities;
using LogChallenge.Domain.Interfaces.Repositories;
using LogChallenge.Infra.Data.Contexts;
using LogChallenge.Infra.Data.Repositories.Generic;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LogChallenge.Infra.Data.Repositories
{
    public class LogRepository : BaseRepository<Log>, ILogRepository
    {
        protected readonly Context _context;

        public LogRepository(Context context) : base(context)
        {
            _context = context;
        }

        public async Task LogAddRange(List<Log> logList)
        {
            await _context.AddRangeAsync(logList);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> LogExists(Log log)
        {
            return await _context.Log.AnyAsync(a => a.Host == log.Host &&
                                   a.Identity == log.Identity &&
                                   a.User == log.User &&
                                   a.DateTime == log.DateTime &&
                                   a.Request == log.Request &&
                                   a.StatusCode == log.StatusCode &&
                                   a.Size == log.Size &&
                                   a.Referer == log.Referer &&
                                   a.UserAgent == log.UserAgent);
        }
    }
}
