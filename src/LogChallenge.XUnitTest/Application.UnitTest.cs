using AutoMapper;
using LogChallenge.Application;
using LogChallenge.Application.Services;
using LogChallenge.Domain.Interfaces.Repositories;
using LogChallenge.Domain.Services;
using LogChallenge.XUnitTest.Entities;
using Moq;
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
        public void GetById_Guid_ReturnsLog()
        {
            // Arrange
            var log = _logFake.GenerateFull();
            _logRepository.Setup(x => x.GetById(log.Id)).ReturnsAsync(log);

            // Act            
            var result = _logApplicationService.GetById(log.Id).Result;

            // Assert
            Assert.Equal(result.Id, log.Id);
            Assert.Equal(result.Host, log.Host);
            Assert.Equal(result.Identity, log.Identity);
        }
    }
}