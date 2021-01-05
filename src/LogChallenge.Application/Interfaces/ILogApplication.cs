using LogChallenge.Application.Interfaces.Generics;
using LogChallenge.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogChallenge.Application.Interfaces
{
    public interface ILogApplication : IGenericApplication<Log>
    {
        Task AddLog(Log log);
        Task UpdateLog(Log log);
    }
}
