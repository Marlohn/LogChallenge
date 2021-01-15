using AutoMapper;
using Bogus;
using LogChallenge.Application;
using LogChallenge.Application.Dto;
using LogChallenge.Application.Services;
using LogChallenge.Domain.Entities;
using LogChallenge.Domain.Interfaces.Repositories;
using LogChallenge.Domain.Services;
using LogChallenge.XUnitTest.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Internal;
using Moq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Xunit;

namespace LogChallenge.XUnitTest
{
    public class Application
    {
        private readonly Mock<ILogRepository> _logRepository;
        private readonly LogService _logService;
        private readonly IMapper _mapper;
        private readonly LogApplicationService _logApplicationService;
        private readonly LogFake _logFake;

        public Application()
        {
            _logRepository = new Mock<ILogRepository>();
            _logService = new LogService(_logRepository.Object);
            _mapper = new MapperConfiguration(c => c.AddProfile<MapEntities>()).CreateMapper();
            _logApplicationService = new LogApplicationService(_mapper, _logService);
            _logFake = new LogFake();
        }

        //---- LOG ADD --------------------------------------------------------------------//

        [Fact]
        public void LogAdd_ReturnLogWithoutNotifications()
        {
            // Arrange
            var log = _logFake.Generate();
            _logRepository.Setup(x => x.Add(log)).ReturnsAsync(log.Id);

            // Act            
            var result = _logApplicationService.LogAdd(_mapper.Map<LogDto>(log)).Result;

            // Assert
            _logRepository.Verify(a => a.Add(It.IsAny<Log>()), Times.Once);
            Assert.True(result.Notifications.Count == 0);
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData("MORECHARACTERSTHANALLOWED")]
        public void LogAdd_HostInvalidParameterReturnNotification(string Host)
        {
            // Arrange
            var log = _logFake.Generate();
            log.Host = Host;
            _logRepository.Setup(x => x.Add(log)).ReturnsAsync(log.Id);

            // Act            
            var result = _logApplicationService.LogAdd(_mapper.Map<LogDto>(log)).Result;

            // Assert
            _logRepository.Verify(a => a.Add(It.IsAny<Log>()), Times.Never);
            Assert.True(result.Notifications.Count > 0);
        }

        [Theory]
        [InlineData("MORECHARACTERSTHANALLOWEDMORECHARACTERSTHANALLOWEDMORECHARACTERSTHANALLOWED")]
        public void LogAdd_IdentityInvalidParameterReturnNotification(string Identity)
        {
            // Arrange
            var log = _logFake.Generate();
            log.Identity = Identity;
            _logRepository.Setup(x => x.Add(log)).ReturnsAsync(log.Id);

            // Act            
            var result = _logApplicationService.LogAdd(_mapper.Map<LogDto>(log)).Result;

            // Assert
            _logRepository.Verify(a => a.Add(It.IsAny<Log>()), Times.Never);
            Assert.True(result.Notifications.Count > 0);
        }

        [Theory]
        [InlineData("MORECHARACTERSTHANALLOWEDMORECHARACTERSTHANALLOWEDMORECHARACTERSTHANALLOWED")]
        public void LogAdd_UserInvalidParameterReturnNotification(string User)
        {
            // Arrange
            var log = _logFake.Generate();
            log.User = User;
            _logRepository.Setup(x => x.Add(log)).ReturnsAsync(log.Id);

            // Act            
            var result = _logApplicationService.LogAdd(_mapper.Map<LogDto>(log)).Result;

            // Assert
            _logRepository.Verify(a => a.Add(It.IsAny<Log>()), Times.Never);
            Assert.True(result.Notifications.Count > 0);
        }

        [Theory]
        [InlineData(null)]
        public void LogAdd_DateTimeInvalidParameterReturnNotification(DateTime DateTime)
        {
            // Arrange
            var log = _logFake.Generate();
            log.DateTime = DateTime;
            _logRepository.Setup(x => x.Add(log)).ReturnsAsync(log.Id);

            // Act            
            var result = _logApplicationService.LogAdd(_mapper.Map<LogDto>(log)).Result;

            // Assert
            _logRepository.Verify(a => a.Add(It.IsAny<Log>()), Times.Never);
            Assert.True(result.Notifications.Count > 0);
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData("MORECHARACTERSTHANALLOWEDMORECHARACTERSTHANALLOWEDMORECHARACTERSTHANALLOWEDMORECHARACTERSTHANALLOWEDMORECHARACTERSTHANALLOWEDMORECHARACTERSTHANALLOWEDMORECHARACTERSTHANALLOWEDMORECHARACTERSTHANALLOWEDMORECHARACTERSTHANALLOWEDMORECHARACTERSTHANALLOWEDMORECHARACTERSTHANALLOWED")]
        public void LogAdd_RequestInvalidParameterReturnNotification(string Request)
        {
            // Arrange
            var log = _logFake.Generate();
            log.Request = Request;
            _logRepository.Setup(x => x.Add(log)).ReturnsAsync(log.Id);

            // Act            
            var result = _logApplicationService.LogAdd(_mapper.Map<LogDto>(log)).Result;

            // Assert
            _logRepository.Verify(a => a.Add(It.IsAny<Log>()), Times.Never);
            Assert.True(result.Notifications.Count > 0);
        }

        [Theory]
        [InlineData(null)]
        [InlineData(1)]
        [InlineData(99)]
        [InlineData(1000)]
        public void LogAdd_StatusCodeInvalidParameterReturnNotification(int StatusCode)
        {
            // Arrange
            var log = _logFake.Generate();
            log.StatusCode = StatusCode;
            _logRepository.Setup(x => x.Add(log)).ReturnsAsync(log.Id);

            // Act            
            var result = _logApplicationService.LogAdd(_mapper.Map<LogDto>(log)).Result;

            // Assert
            _logRepository.Verify(a => a.Add(It.IsAny<Log>()), Times.Never);
            Assert.True(result.Notifications.Count > 0);
        }

        [Theory]
        [InlineData(-1)]
        public void LogAdd_SizeInvalidParameterReturnNotification(int Size)
        {
            // Arrange
            var log = _logFake.Generate();
            log.Size = Size;
            _logRepository.Setup(x => x.Add(log)).ReturnsAsync(log.Id);

            // Act            
            var result = _logApplicationService.LogAdd(_mapper.Map<LogDto>(log)).Result;

            // Assert
            _logRepository.Verify(a => a.Add(It.IsAny<Log>()), Times.Never);
            Assert.True(result.Notifications.Count > 0);
        }

        [Theory]
        [InlineData("MORECHARACTERSTHANALLOWEDMORECHARACTERSTHANALLOWEDMORECHARACTERSTHANALLOWEDMORECHARACTERSTHANALLOWEDMORECHARACTERSTHANALLOWEDMORECHARACTERSTHANALLOWEDMORECHARACTERSTHANALLOWEDMORECHARACTERSTHANALLOWEDMORECHARACTERSTHANALLOWEDMORECHARACTERSTHANALLOWEDMORECHARACTERSTHANALLOWED")]
        public void LogAdd_RefererInvalidParameterReturnNotification(string Referer)
        {
            // Arrange
            var log = _logFake.Generate();
            log.Referer = Referer;
            _logRepository.Setup(x => x.Add(log)).ReturnsAsync(log.Id);

            // Act            
            var result = _logApplicationService.LogAdd(_mapper.Map<LogDto>(log)).Result;

            // Assert
            _logRepository.Verify(a => a.Add(It.IsAny<Log>()), Times.Never);
            Assert.True(result.Notifications.Count > 0);
        }

        [Theory]
        [InlineData("MORECHARACTERSTHANALLOWEDMORECHARACTERSTHANALLOWEDMORECHARACTERSTHANALLOWEDMORECHARACTERSTHANALLOWEDMORECHARACTERSTHANALLOWEDMORECHARACTERSTHANALLOWEDMORECHARACTERSTHANALLOWEDMORECHARACTERSTHANALLOWEDMORECHARACTERSTHANALLOWEDMORECHARACTERSTHANALLOWEDMORECHARACTERSTHANALLOWED")]
        public void LogAdd_UserAgentInvalidParameterReturnNotification(string UserAgent)
        {
            // Arrange
            var log = _logFake.Generate();
            log.UserAgent = UserAgent;
            _logRepository.Setup(x => x.Add(log)).ReturnsAsync(log.Id);

            // Act            
            var result = _logApplicationService.LogAdd(_mapper.Map<LogDto>(log)).Result;

            // Assert
            _logRepository.Verify(a => a.Add(It.IsAny<Log>()), Times.Never);
            Assert.True(result.Notifications.Count > 0);
        }

        //---- LOG UPDATE --------------------------------------------------------------------//

        [Fact]
        public void LogUpdate_ReturnLogWithoutNotifications()
        {
            // Arrange
            var log = _logApplicationService.LogAdd(_mapper.Map<LogDto>(_logFake.Generate())).Result;
            log.Host = "localhost";

            // Act            
            var result = _logApplicationService.LogUpdate(_mapper.Map<LogDto>(log)).Result;

            // Assert
            _logRepository.Verify(a => a.Add(It.IsAny<Log>()), Times.Once);
            Assert.Equal(result.Host, log.Host);
            Assert.True(result.Notifications.Count == 0); ;
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData("MORECHARACTERSTHANALLOWED")]
        public void LogUpdateHostInvalidParameterReturnNotification(string Host)
        {
            // Arrange
            var log = _logApplicationService.LogAdd(_mapper.Map<LogDto>(_logFake.Generate())).Result;
            log.Host = Host;

            // Act            
            var result = _logApplicationService.LogUpdate(_mapper.Map<LogDto>(log)).Result;

            // Assert
            _logRepository.Verify(a => a.Add(It.IsAny<Log>()), Times.Once);
            Assert.True(result.Notifications.Count > 0);
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData("MORECHARACTERSTHANALLOWED")]
        public void LogUpdate_HostInvalidParameterReturnNotification(string Host)
        {
            // Arrange
            var log = _logApplicationService.LogAdd(_mapper.Map<LogDto>(_logFake.Generate())).Result;
            log.Host = Host;

            // Act            
            var result = _logApplicationService.LogUpdate(_mapper.Map<LogDto>(log)).Result;

            // Assert
            _logRepository.Verify(a => a.Add(It.IsAny<Log>()), Times.Once);
            Assert.True(result.Notifications.Count > 0);
        }

        [Theory]
        [InlineData("MORECHARACTERSTHANALLOWEDMORECHARACTERSTHANALLOWEDMORECHARACTERSTHANALLOWED")]
        public void LogUpdate_IdentityInvalidParameterReturnNotification(string Identity)
        {
            // Arrange
            var log = _logApplicationService.LogAdd(_mapper.Map<LogDto>(_logFake.Generate())).Result;
            log.Identity = Identity;

            // Act            
            var result = _logApplicationService.LogUpdate(_mapper.Map<LogDto>(log)).Result;

            // Assert
            _logRepository.Verify(a => a.Add(It.IsAny<Log>()), Times.Once);
            Assert.True(result.Notifications.Count > 0);
        }

        [Theory]
        [InlineData("MORECHARACTERSTHANALLOWEDMORECHARACTERSTHANALLOWEDMORECHARACTERSTHANALLOWED")]
        public void LogUpdate_UserInvalidParameterReturnNotification(string User)
        {
            // Arrange
            var log = _logApplicationService.LogAdd(_mapper.Map<LogDto>(_logFake.Generate())).Result;
            log.User = User;

            // Act            
            var result = _logApplicationService.LogUpdate(_mapper.Map<LogDto>(log)).Result;

            // Assert
            _logRepository.Verify(a => a.Add(It.IsAny<Log>()), Times.Once);
            Assert.True(result.Notifications.Count > 0);
        }

        [Theory]
        [InlineData(null)]
        public void LogUpdate_DateTimeInvalidParameterReturnNotification(DateTime DateTime)
        {
            // Arrange
            var log = _logApplicationService.LogAdd(_mapper.Map<LogDto>(_logFake.Generate())).Result;
            log.DateTime = DateTime;

            // Act            
            var result = _logApplicationService.LogUpdate(_mapper.Map<LogDto>(log)).Result;

            // Assert
            _logRepository.Verify(a => a.Add(It.IsAny<Log>()), Times.Once);
            Assert.True(result.Notifications.Count > 0);
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData("MORECHARACTERSTHANALLOWEDMORECHARACTERSTHANALLOWEDMORECHARACTERSTHANALLOWEDMORECHARACTERSTHANALLOWEDMORECHARACTERSTHANALLOWEDMORECHARACTERSTHANALLOWEDMORECHARACTERSTHANALLOWEDMORECHARACTERSTHANALLOWEDMORECHARACTERSTHANALLOWEDMORECHARACTERSTHANALLOWEDMORECHARACTERSTHANALLOWED")]
        public void LogUpdate_RequestInvalidParameterReturnNotification(string Request)
        {
            // Arrange
            var log = _logApplicationService.LogAdd(_mapper.Map<LogDto>(_logFake.Generate())).Result;
            log.Request = Request;

            // Act            
            var result = _logApplicationService.LogUpdate(_mapper.Map<LogDto>(log)).Result;

            // Assert
            _logRepository.Verify(a => a.Add(It.IsAny<Log>()), Times.Once);
            Assert.True(result.Notifications.Count > 0);
        }

        [Theory]
        [InlineData(null)]
        [InlineData(1)]
        [InlineData(99)]
        [InlineData(1000)]
        public void LogUpdate_StatusCodeInvalidParameterReturnNotification(int StatusCode)
        {
            // Arrange
            var log = _logApplicationService.LogAdd(_mapper.Map<LogDto>(_logFake.Generate())).Result;
            log.StatusCode = StatusCode;

            // Act            
            var result = _logApplicationService.LogUpdate(_mapper.Map<LogDto>(log)).Result;

            // Assert
            _logRepository.Verify(a => a.Add(It.IsAny<Log>()), Times.Once);
            Assert.True(result.Notifications.Count > 0);
        }

        [Theory]
        [InlineData(-1)]
        public void LogUpdate_SizeInvalidParameterReturnNotification(int Size)
        {
            // Arrange
            var log = _logApplicationService.LogAdd(_mapper.Map<LogDto>(_logFake.Generate())).Result;
            log.Size = Size;

            // Act            
            var result = _logApplicationService.LogUpdate(_mapper.Map<LogDto>(log)).Result;

            // Assert
            _logRepository.Verify(a => a.Add(It.IsAny<Log>()), Times.Once);
            Assert.True(result.Notifications.Count > 0);
        }

        [Theory]
        [InlineData("MORECHARACTERSTHANALLOWEDMORECHARACTERSTHANALLOWEDMORECHARACTERSTHANALLOWEDMORECHARACTERSTHANALLOWEDMORECHARACTERSTHANALLOWEDMORECHARACTERSTHANALLOWEDMORECHARACTERSTHANALLOWEDMORECHARACTERSTHANALLOWEDMORECHARACTERSTHANALLOWEDMORECHARACTERSTHANALLOWEDMORECHARACTERSTHANALLOWED")]
        public void LogUpdate_RefererInvalidParameterReturnNotification(string Referer)
        {
            // Arrange
            var log = _logApplicationService.LogAdd(_mapper.Map<LogDto>(_logFake.Generate())).Result;
            log.Referer = Referer;

            // Act            
            var result = _logApplicationService.LogUpdate(_mapper.Map<LogDto>(log)).Result;

            // Assert
            _logRepository.Verify(a => a.Add(It.IsAny<Log>()), Times.Once);
            Assert.True(result.Notifications.Count > 0);
        }

        //---- CONVERT FILE TO LOG --------------------------------------------------------------//
        [Fact]
        public void ConvertFileToLog_InvalidFileReturnEmptyLogList()
        {
            // Arrange
            IFormFile InvalidFile = new FormFile(new MemoryStream(Encoding.UTF8.GetBytes(@"some invalid bytes")), 0, 0, "data", "sample.png");

            // Act  
            var result = _logApplicationService.ConvertFileToLog(InvalidFile).Result;

            // Assert
            Assert.True(result.Count == 0);
        }

        //---- LOG ADD RANGE --------------------------------------------------------------------//
        [Fact]
        public void LogAddRange_ReturnListLogWithoutNotifications()
        {
            // Arrange
            var itens_to_add = new Faker().Random.Number(2, 10);
            var logList = _logFake.Generate(itens_to_add);

            // Act            
            var result = _logApplicationService.LogAddRange(_mapper.Map<List<LogDto>>(logList)).Result;

            // Assert
            _logRepository.Verify(a => a.LogAddRange(It.IsAny<List<Log>>()), Times.Once);
            Assert.True(result.Count == itens_to_add);
            Assert.True(result.Count(a => a.Notifications.Count > 0) == 0);
        }

        [Fact]
        public void LogAddRange_ReturnListLogWithNotifications()
        {
            // Arrange
            var itens_to_add = new Faker().Random.Number(2, 10);
            var itens_with_notification = new Faker().Random.Number(1, itens_to_add);
            var logList = _logFake.Generate(itens_to_add, itens_with_notification);

            // Act            
            var result = _logApplicationService.LogAddRange(_mapper.Map<List<LogDto>>(logList)).Result;

            // Assert
            _logRepository.Verify(a => a.LogAddRange(It.IsAny<List<Log>>()), Times.Once);
            Assert.True(result.Count == itens_to_add);
            Assert.True(result.Count(a => a.Notifications.Count > 0) == itens_with_notification);
        }

    }
}