using LogChallenge.Domain.Entities;
using LogChallenge.Domain.Interfaces.Services.Generic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace LogChallenge.Domain.Interfaces.Services
{
    public interface ILogService : IBaseService<Log>
    {
        Task AddLog(Log log);
        Task UpdateLog(Log log);
    }
}
