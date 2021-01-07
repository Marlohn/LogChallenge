using AutoMapper;
using LogChallenge.Application.Dto.Generic;
using LogChallenge.Application.Interfaces.Generic;
using LogChallenge.Domain.Entities.Generic;
using LogChallenge.Domain.Interfaces.Services.Generic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogChallenge.Application.Services.Generic
{

    public class BaseApplicationService<T, TDto> : IBaseApplication<T, TDto> where T : BaseEntity where TDto : BaseEntityDto
    {
        protected readonly IBaseService<T> servico;
        protected readonly IMapper iMapper;

        public BaseApplicationService(IMapper iMapper, IBaseService<T> servico) : base()
        {
            this.iMapper = iMapper;
            this.servico = servico;
        }

        public async Task Add(TDto entity)
        {
            await servico.Add(iMapper.Map<T>(entity));
        }

        public async Task Delete(Guid id)
        {
            await servico.Delete(iMapper.Map<T>(id));
        }

        public async Task Delete(TDto entity)
        {
            await servico.Delete(iMapper.Map<T>(entity));
        }

        public async Task Update(TDto entity)
        {
            await servico.Update(iMapper.Map<T>(entity));
        }

        public async Task<List<TDto>> List()
        {
            return iMapper.Map<List<TDto>>(await servico.List());
        }

        public async Task<TDto> SelectById(Guid id)
        {
           return iMapper.Map<TDto>(await servico.SelectById(id));
        }

    }
}
