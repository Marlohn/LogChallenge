using LogChallenge.Domain.Entities;
using LogChallenge.Domain.Interfaces.Repositories;
using LogChallenge.Infra.Data.Contexts;
using LogChallenge.Infra.Data.Repositories.Generic;
using System;
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

        public async Task AddLog(Log log)
        {
            //Registra em alguma base de dados
            throw new NotImplementedException();
        }

        public async Task UpdateLog(Log log)
        {
            //Registra em alguma base de dados
            throw new NotImplementedException();
        }

        public async Task<List<Log>> LogAddRange(List<Log> logList)
        {
            await _context.AddRangeAsync(logList);
            await _context.SaveChangesAsync();

            return logList;
        }

    }
}
