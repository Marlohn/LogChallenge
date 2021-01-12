using AutoMapper;
using LogChallenge.Application.Interfaces;
using LogChallenge.Application.Interfaces.Generic;
using LogChallenge.Application.Services;
using LogChallenge.Application.Services.Generic;
using LogChallenge.Domain.Interfaces.Repositories;
using LogChallenge.Domain.Interfaces.Repositories.Generic;
using LogChallenge.Domain.Interfaces.Services;
using LogChallenge.Domain.Interfaces.Services.Generic;
using LogChallenge.Domain.Services;
using LogChallenge.Domain.Services.Generic;
using LogChallenge.Infra.Data.Contexts;
using LogChallenge.Infra.Data.Repositories;
using LogChallenge.Infra.Data.Repositories.Generic;
using Microsoft.Extensions.DependencyInjection;

namespace LogChallenge.Infra.IoC
{
    public class DependencyInjector
    {
        public static void Registry(IServiceCollection svcCollection)
        {
            //Aplicação
            svcCollection.AddScoped(typeof(IBaseApplication<,>), typeof(BaseApplicationService<,>));
            svcCollection.AddScoped<ILogApplication, LogApplicationService>();
            svcCollection.AddAutoMapper(typeof(LogApplicationService));

            //Domínio
            svcCollection.AddScoped(typeof(IBaseService<>), typeof(BaseService<>));
            svcCollection.AddScoped<ILogService, LogService>();
            svcCollection.AddAutoMapper(typeof(LogService));

            //Repositorio
            svcCollection.AddScoped(typeof(IBaseRepository<>), typeof(BaseRepository<>));
            svcCollection.AddScoped<ILogRepository, LogRepository>();

            //Context
            svcCollection.AddDbContext<Context>(ServiceLifetime.Scoped);
        }
    }
}
