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

        public async Task<Log> LogAdd(Log log)
        {
            //var nameValidation = log.isString(log.User, "User");
            //var statusValidation = log.isPositiveInteger(log.StatusCode, "StatusCode");

            //if (nameValidation && statusValidation)
            //{
            //    await _logRepository.Add(log);
            //}

            await _logRepository.Add(log);

            return log;
        }

        public async Task<Log> LogUpdate(Log log)
        {
            //var nameValidation = log.isString(log.User, "User");
            //var statusValidation = log.isPositiveInteger(log.StatusCode, "StatusCode");

            //if (nameValidation && statusValidation)
            //{
            //    await _logRepository.Update(log);
            //}

            return log;
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
                    LogListOK.Add(log);
                }
            }

            await _logRepository.LogAddRange(LogListOK);

            return logList;
        }

    }
}
