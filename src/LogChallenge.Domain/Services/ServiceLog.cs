using LogChallenge.Domain.Interfaces;
using LogChallenge.Domain.Interfaces.Services;
using LogChallenge.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogChallenge.Domain.Services
{
    public class ServiceLog : IServiceLog
    {
        private readonly ILog _ILog;
        public ServiceLog(ILog Ilog) 
        {
            _ILog = Ilog;
        }

        public async Task AddLog(Log log)
        {
            var nameValidation = log.isString(log.User, "User");
            var statusValidation = log.isPositiveInteger(log.StatusCode, "StatusCode");

            if (nameValidation && statusValidation)
            {
                //log.State = true;
                await _ILog.Add(log);
            }
        }

        public async Task UpdateLog(Log log)
        {
            var nameValidation = log.isString(log.User, "User");
            var statusValidation = log.isPositiveInteger(log.StatusCode, "StatusCode");

            if (nameValidation && statusValidation)
            {
                await _ILog.Update(log);
            }
        }
    }
}
