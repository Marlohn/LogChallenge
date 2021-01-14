using LogChallenge.Domain.Entities;
using LogChallenge.Domain.Interfaces.Repositories;
using LogChallenge.Infra.IoC;
using Microsoft.Extensions.DependencyInjection;
using System;
using Xunit;

namespace LogChallenge.XUnitTest
{
    public class Infra
    {

        public Infra()
        {

        }

        [Fact]
        public async void GetById_Guid_ReturnsLog()
        {
            var collection = new ServiceCollection();
            DependencyInjector.Registry(collection);
            var serviceProvider = collection.BuildServiceProvider();
            var LogRepository = serviceProvider.GetService<ILogRepository>();

            var result = await LogRepository.GetById(new Guid("f3de30b1-205a-4f75-846b-299c1e166da0"));

            Assert.NotNull(result);
            Assert.IsType<Log>(result);
        }
    }
}