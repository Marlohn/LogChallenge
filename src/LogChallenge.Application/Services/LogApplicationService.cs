using AutoMapper;
using LogChallenge.Application.Dto;
using LogChallenge.Application.Dto.Generic;
using LogChallenge.Application.Interfaces;
using LogChallenge.Application.Services.Generic;
using LogChallenge.Domain.Entities;
using LogChallenge.Domain.Interfaces.Services;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace LogChallenge.Application.Services
{
    public class LogApplicationService : BaseApplicationService<Log, LogDto>, ILogApplication
    {
        protected readonly ILogService _logService;
        protected readonly IMapper _mapper;

        public LogApplicationService(IMapper mapper, ILogService logService) : base(mapper, logService)
        {
            _mapper = mapper;
            _logService = logService;
        }

        public async Task<LogDto> LogUpdate(LogDto logDto)
        {
            var log = await _logService.LogUpdate(_mapper.Map<Log>(logDto));
            return _mapper.Map<LogDto>(log);
        }

        public async Task<LogDto> LogAdd(LogDto logDto)
        {
            var log = await _logService.LogAdd(_mapper.Map<Log>(logDto));
            return _mapper.Map<LogDto>(log); 
        }

        public async Task<List<LogDto>> LogAddRange(List<LogDto> logDtoList)
        {
            return _mapper.Map<List<LogDto>>(await _logService.LogAddRange(_mapper.Map<List<Log>>(logDtoList)));
        }

        public async Task<List<LogDto>> ConvertFileToLog(IFormFile file)
        {
            Regex regex = new Regex("^(?<host>\\S+) (?<identity>\\S+) (?<user>\\S+) \\[(?<dateTime>[\\w:/]+\\s[+\\-]\\d{4})\\] \"(?<request>.+?)\" (?<statusCode>\\d{3}) (?<size>\\d+|-) ?\"?(?<referer>[^\"]*)\"? ?\"?(?<userAgent>[^\"]*)?\"?$");

            var LogList = new List<LogDto>();
            using (var reader = new StreamReader(file.OpenReadStream()))
            {
                string line;
                int lineCount = 0;
                while ((line = await reader.ReadLineAsync()) != null)
                {
                    var currentLog = new LogDto();
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
                            currentLog.Notifications.Add(new NotificationDto
                            {
                                Message = "Invalid property value",
                                PropertyName = "Line " + lineCount
                            });
                        }
                    }
                    else
                    {
                        currentLog.Notifications.Add(new NotificationDto
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
