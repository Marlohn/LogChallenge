using LogChallenge.Domain.Entities;
using LogChallenge.Domain.Entities.Generic;
using LogChallenge.Domain.Interfaces.Repositories;
using LogChallenge.Domain.Interfaces.Services;
using LogChallenge.Domain.Services.Generic;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Text.RegularExpressions;
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
            //var nameValidation = log.IsNullOrEmpty(log.User, "User");
            //var statusValidation = log.IsNumeric(log.StatusCode, "StatusCode");

            //if (nameValidation && statusValidation)
            //{
            //    await _logRepository.Add(log);
            //}

            await _logRepository.Add(log);
            return log;
        }

        public async Task<Log> LogUpdate(Log log)
        {
            //var nameValidation = log.IsNullOrEmpty(log.User, "User");
            //var statusValidation = log.IsNumeric(log.StatusCode, "StatusCode");

            //if (nameValidation && statusValidation)
            //{
            //    await _logRepository.Update(log);
            //}

            await _logRepository.Update(log);
            return log;
        }

        public async Task<List<Log>> LogAddRange(List<Log> logList)
        {
            //var LogListOK = new List<Log>();
            //foreach (var log in logList)
            //{
            //    var nameValidation = log.IsNullOrEmpty(log.Host, "Host");

            //    var statusValidation = log.IsNumeric(log.StatusCode, "StatusCode");

            //    if (nameValidation && statusValidation)
            //    {
            //        LogListOK.Add(log);
            //    }
            //}

            //await _logRepository.LogAddRange(LogListOK);

            await _logRepository.LogAddRange(logList);
            return logList;
        }

        public async Task<List<Log>> ConvertFileToLog(IFormFile file)
        {
            Regex regex = new Regex("^(?<host>\\S+) (?<identity>\\S+) (?<user>\\S+) \\[(?<dateTime>[\\w:/]+\\s[+\\-]\\d{4})\\] \"(?<request>.+?)\" (?<statusCode>\\d{3}) (?<size>\\d+|-) ?\"?(?<referer>[^\"]*)\"? ?\"?(?<userAgent>[^\"]*)?\"?$");

            var LogList = new List<Log>();
            using (var reader = new StreamReader(file.OpenReadStream()))
            {
                string line;
                int lineCount = 0;
                while ((line = await reader.ReadLineAsync()) != null)
                {
                    var currentLog = new Log();
                    lineCount++;

                    // Try to match each line against the Regex.
                    Match match = regex.Match(line);
                    if (match.Success)
                    {
                        try
                        {
                            currentLog.Host = match.Groups["host"].Value;
                            currentLog.Identity = match.Groups["identity"].Value != "-" ? match.Groups["identity"].Value : null;
                            currentLog.User = match.Groups["user"].Value != "-" ? match.Groups["user"].Value : null;
                            currentLog.DateTime = DateTime.ParseExact(match.Groups["dateTime"].Value, "dd/MMM/yyyy:HH:mm:ss K", CultureInfo.InvariantCulture);
                            currentLog.Request = match.Groups["request"].Value;
                            currentLog.StatusCode = Convert.ToInt32(match.Groups["statusCode"].Value);
                            currentLog.Size = match.Groups["size"].Value != "-" ? Convert.ToInt32(match.Groups["size"].Value) : null;
                            currentLog.Referer = match.Groups["referer"].Value;
                            currentLog.UserAgent = match.Groups["userAgent"].Value;
                        }
                        catch (Exception)
                        {
                            currentLog.Notifications.Add(new Notification
                            {
                                Message = "Invalid property value",
                                PropertyName = "Line " + lineCount
                            });
                        }
                    }
                    else
                    {
                        currentLog.Notifications.Add(new Notification
                        {
                            Message = "Content does not math regex",
                            PropertyName = "Line " + lineCount
                        });
                    }

                    LogList.Add(currentLog);
                }
            }

            return LogList;
        }
    }
}
