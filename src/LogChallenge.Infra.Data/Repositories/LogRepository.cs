using LogChallenge.Domain.Entities;
using LogChallenge.Domain.Interfaces.Repositories;
using LogChallenge.Infra.Data.Contexts;
using LogChallenge.Infra.Data.Repositories.Generic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
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

    }
}
