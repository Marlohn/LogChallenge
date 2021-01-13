using LogChallenge.Domain.Entities;
using LogChallenge.Domain.Interfaces.Repositories;
using LogChallenge.Domain.Interfaces.Services;
using LogChallenge.Domain.Services.Generic;
using System;
using System.Collections.Generic;
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

        public async Task LogAdd(Log log)
        {
            var nameValidation = log.isString(log.User, "User");
            var statusValidation = log.isPositiveInteger(log.StatusCode, "StatusCode");

            if (nameValidation && statusValidation)
            {
                log.RegDate = DateTime.Now;
                log.UpdateDate = DateTime.Now;

                await _logRepository.Add(log);
            }
        }

        public async Task LogUpdate(Log log)
        {
            var nameValidation = log.isString(log.User, "User");
            var statusValidation = log.isPositiveInteger(log.StatusCode, "StatusCode");

            if (nameValidation && statusValidation)
            {
                log.UpdateDate = DateTime.Now;
                await _logRepository.Update(log);
            }
        }

        public async Task<List<Log>> LogAddRange(List<Log> logList)
        {
            var LogListOK = new List<Log>();
            foreach (var log in logList)
            {
                var nameValidation = log.isString(log.User, "User");
                var statusValidation = log.isPositiveInteger(log.StatusCode, "StatusCode");

                if (nameValidation && statusValidation)
                {
                    log.RegDate = DateTime.Now;
                    log.UpdateDate = DateTime.Now;

                    LogListOK.Add(log);
                }
            }

            return await _logRepository.LogAddRange(LogListOK);
        }

    }
}
