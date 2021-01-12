using LogChallenge.Application.Dto;
using LogChallenge.Application.Interfaces.Generic;
using LogChallenge.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace LogChallenge.Application.Interfaces
{
    public interface ILogApplication : IBaseApplication<Log, LogDto>
    {
        Task AddLog(LogDto log);
        Task UpdateLog(LogDto log);
    }
}
