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

        [Fact]
        public void LogAdd_ReturnGuidAndErrorCountZero()
        {
            // Arrange
            var log = _logFake.GenerateFull();
            _logRepository.Setup(x => x.Add(log)).ReturnsAsync(log.Id);

            // Act            
            var result = _logApplicationService.LogAdd(_mapper.Map<LogDto>(log)).Result;

            // Assert
            _logRepository.Verify(a => a.Add(It.IsAny<Log>()), Times.Once);
            Assert.IsType<Guid>(result);
        }



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