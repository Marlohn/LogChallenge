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
        protected readonly IBaseService<T> _Service;
        protected readonly IMapper _iMapper;

        public BaseApplicationService(IMapper iMapper, IBaseService<T> servico) : base()
        {
            _iMapper = iMapper;
            _Service = servico;
        }

        public async Task Add(TDto entity)
        {
            await _Service.Add(_iMapper.Map<T>(entity));
        }

        public async Task Delete(Guid id)
        {
            await _Service.Delete(_iMapper.Map<T>(id));
        }

        public async Task Delete(TDto entity)
        {
            await _Service.Delete(_iMapper.Map<T>(entity));
        }

        public async Task Update(TDto entity)
        {
            await _Service.Update(_iMapper.Map<T>(entity));
        }

        public async Task<List<TDto>> List()
        {
            return _iMapper.Map<List<TDto>>(await _Service.List());
        }

        public async Task<TDto> SelectById(Guid id)
        {
           return _iMapper.Map<TDto>(await _Service.SelectById(id));
        }

    }
}
