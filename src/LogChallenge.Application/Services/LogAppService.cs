using LogChallenge.Application.Interfaces;
using LogChallenge.Domain.Interfaces;
using LogChallenge.Domain.Interfaces.Services;
using LogChallenge.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogChallenge.Application.Services
{
    public class LogAppService : ILogApplication
    {

        ILog _ILog;
        IServiceLog _IServiceLog;
        public LogAppService(ILog ILog, IServiceLog IServiceLog)
        {
            _ILog = ILog;
            _IServiceLog = IServiceLog;
        }

        #region Custom Methods

        public async Task AddLog(Log log)
        {
            await _IServiceLog.AddLog(log);
        }

        public async Task UpdateLog(Log log)
        {
            await _IServiceLog.UpdateLog(log);
        }

        #endregion

        #region Default Methods

        public async Task Add(Log Object)
        {
            await _ILog.Add(Object);
        }

        public async Task Delete(Log Object)
        {
            await _ILog.Delete(Object);
        }

        public async Task Update(Log Object)
        {
            await _ILog.Update(Object);
        }

        public async Task<List<Log>> List()
        {
            return await _ILog.List();
        }

        public async Task<Log> GetEntityById(Guid Id)
        {
           return await _ILog.GetEntityById(Id);
        }

        #endregion

    }
}
