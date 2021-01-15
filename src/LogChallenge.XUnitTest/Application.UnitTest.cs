using AutoMapper;
using LogChallenge.Application;
using LogChallenge.Application.Dto;
using LogChallenge.Application.Services;
using LogChallenge.Domain.Entities;
using LogChallenge.Domain.Interfaces.Repositories;
using LogChallenge.Domain.Services;
using LogChallenge.XUnitTest.Entities;
using Moq;
using System;
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
        public void LogAdd_ReturnLogWithNotificationsCountZero()
        {
            // Arrange
            var log = _logFake.GenerateFull();
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
            var log = _logFake.GenerateFull();
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
            var log = _logFake.GenerateFull();
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
            var log = _logFake.GenerateFull();
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
            var log = _logFake.GenerateFull();
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
            var log = _logFake.GenerateFull();
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
            var log = _logFake.GenerateFull();
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
            var log = _logFake.GenerateFull();
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
            var log = _logFake.GenerateFull();
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
            var log = _logFake.GenerateFull();
            log.UserAgent = UserAgent;
            _logRepository.Setup(x => x.Add(log)).ReturnsAsync(log.Id);

            // Act            
            var result = _logApplicationService.LogAdd(_mapper.Map<LogDto>(log)).Result;

            // Assert
            _logRepository.Verify(a => a.Add(It.IsAny<Log>()), Times.Never);
            Assert.True(result.Notifications.Count > 0);
        }

        //---- LOG UPDATE --------------------------------------------------------------------//

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData("MORECHARACTERSTHANALLOWED")]
        public void LogUpdateHostInvalidParameterReturnNotification(string Host)
        {
            // Arrange
            var log = _logApplicationService.LogAdd(_mapper.Map<LogDto>(_logFake.GenerateFull())).Result;
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
            var log = _logApplicationService.LogAdd(_mapper.Map<LogDto>(_logFake.GenerateFull())).Result;
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
            var log = _logApplicationService.LogAdd(_mapper.Map<LogDto>(_logFake.GenerateFull())).Result;
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
            var log = _logApplicationService.LogAdd(_mapper.Map<LogDto>(_logFake.GenerateFull())).Result;
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
            var log = _logApplicationService.LogAdd(_mapper.Map<LogDto>(_logFake.GenerateFull())).Result;
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
            var log = _logApplicationService.LogAdd(_mapper.Map<LogDto>(_logFake.GenerateFull())).Result;
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
            var log = _logApplicationService.LogAdd(_mapper.Map<LogDto>(_logFake.GenerateFull())).Result;
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
            var log = _logApplicationService.LogAdd(_mapper.Map<LogDto>(_logFake.GenerateFull())).Result;
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
            var log = _logApplicationService.LogAdd(_mapper.Map<LogDto>(_logFake.GenerateFull())).Result;
            log.Referer = Referer;

            // Act            
            var result = _logApplicationService.LogUpdate(_mapper.Map<LogDto>(log)).Result;

            // Assert
            _logRepository.Verify(a => a.Add(It.IsAny<Log>()), Times.Once);
            Assert.True(result.Notifications.Count > 0);
        }

        //---- LOG ADD RANGE --------------------------------------------------------------------//



    }
}