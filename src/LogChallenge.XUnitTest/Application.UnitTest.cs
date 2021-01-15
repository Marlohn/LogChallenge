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
            var log = _logFake.GenerateFull();
            log.Host = Host;
            _logRepository.Setup(x => x.LogUpdate(log)).ReturnsAsync(log.Id);

            // Act            
            var result = _logApplicationService.LogUpdate(_mapper.Map<LogDto>(log)).Result;

            // Assert
            _logRepository.Verify(a => a.Add(It.IsAny<Log>()), Times.Never);
            Assert.True(result.Notifications.Count > 0);
        }







        //[Theory]
        //[InlineData(null, null, null, null, null, null, null, null, null)]
        //[InlineData("10.1.1.1", null, null, null, null, null, null, null, null)]
        //[InlineData("MORETHEN25CHARACTERSMORETHEN25CHARACTERS", null, null, null, null, null, null, null, null)]
        //public void LogAdd_ReturnLogWithNotifications(string Host, string Identity, string User, DateTime DateTime, string Request, int StatusCode, int Size, string Referer, string UserAgent)
        //{
        //    // Arrange
        //    var log = new Log() { Host = Host, User = User, DateTime = DateTime, Request = Request, StatusCode = StatusCode, Size = Size, Referer = Referer, UserAgent = UserAgent };
        //    _logRepository.Setup(x => x.Add(log)).ReturnsAsync(log.Id);

        //    // Act            
        //    var result = _logApplicationService.LogAdd(_mapper.Map<LogDto>(log)).Result;

        //    // Assert
        //    _logRepository.Verify(a => a.Add(It.IsAny<Log>()), Times.Never);
        //    Assert.True(result.Notifications.Count > 0);
        //}



        //[Fact]
        //public void GetById_Guid_ReturnLog()
        //{
        //    // Arrange
        //    var log = _logFake.GenerateFull();
        //    _logRepository.Setup(x => x.GetById(log.Id)).ReturnsAsync(log);

        //    // Act            
        //    var result = _logApplicationService.GetById(log.Id).Result;

        //    // Assert
        //    Assert.Equal(result.Id, log.Id);

        //    Assert.Equal(result.Host, log.Host);            
        //    Assert.Equal(result.Identity, log.Identity);
        //    Assert.Equal(result.User, log.User);
        //    Assert.Equal(result.DateTime, log.DateTime);            
        //    Assert.Equal(result.Request, log.Request);
        //    Assert.Equal(result.StatusCode, log.StatusCode);
        //    Assert.Equal(result.Size, log.Size);
        //    Assert.Equal(result.Referer, log.Referer);
        //    Assert.Equal(result.UserAgent, log.UserAgent);
        //    Assert.Equal(result.RegDate, log.RegDate);
        //    Assert.Equal(result.UpdateDate, log.UpdateDate);

        //    Assert.NotNull(result);
        //}

        //[Fact]
        //public void Add_Log_ReturnGuid()
        //{
        //    // Arrange
        //    var log = _logFake.GenerateFull();
        //    _logRepository.Setup(x => x.Add(log)).ReturnsAsync(log.Id);

        //    // Act            
        //    var result = _logApplicationService.Add(_mapper.Map<LogDto>(log)).Result;

        //    // Assert
        //    _logRepository.Verify(a => a.Add(It.IsAny<Log>()), Times.Once);
        //    Assert.IsType<Guid>(result);
        //}

        //[Fact]
        //public void Add_Log_ReturnError()
        //{
        //    // Arrange
        //    var log = _logFake.GenerateFull();
        //    _logRepository.Setup(x => x.Add(log)).ReturnsAsync(null);

        //    // Act            
        //    var result = _logApplicationService.Add(_mapper.Map<LogDto>(log)).Result;

        //    // Assert
        //    _logRepository.Verify(a => a.Add(It.IsAny<Log>()), Times.Once);
        //    Assert.IsType<Guid>(result);
        //}
    }
}