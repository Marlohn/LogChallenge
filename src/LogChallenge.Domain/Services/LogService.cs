using LogChallenge.Domain.Entities;
using LogChallenge.Domain.Interfaces.Repositories;
using LogChallenge.Domain.Interfaces.Services;
using LogChallenge.Domain.Services.Generic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace LogChallenge.Domain.Services
{
    public class LogService : BaseService<Log>, ILogService
    {
        protected readonly ILogRepository _logRepository;

        public LogService(ILogRepository logRepository) : base(logRepository)
        {
            _logRepository = logRepository;
        }

        public async Task AddLog(Log log)
        {
            var nameValidation = log.isString(log.User, "User");
            var statusValidation = log.isPositiveInteger(log.StatusCode, "StatusCode");

            if (nameValidation && statusValidation)
            {
                //log.State = true;
                await _logRepository.Add(log);
            }
        }

        public async Task UpdateLog(Log log)
        {
            var nameValidation = log.isString(log.User, "User");
            var statusValidation = log.isPositiveInteger(log.StatusCode, "StatusCode");

            if (nameValidation && statusValidation)
            {
                await _logRepository.Update(log);
            }
        }

    }
}
