using LogChallenge.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogChallenge.Domain.Interfaces.Services
{
    public interface IServiceLog
    {
        Task AddLog(Log log);
        Task UpdateLog(Log log);
    }
}
