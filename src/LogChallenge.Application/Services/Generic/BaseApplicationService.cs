using AutoMapper;
using LogChallenge.Application.Dto.Generic;
using LogChallenge.Application.Interfaces.Generic;
using LogChallenge.Domain.Entities.Generic;
using LogChallenge.Domain.Interfaces.Services.Generic;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LogChallenge.Application.Services.Generic
{

    public class BaseApplicationService<T, TDto> : IBaseApplication<T, TDto> where T : BaseEntity where TDto : BaseEntityDto
    {
        protected readonly IBaseService<T> _service;
        protected readonly IMapper _mapper;

        public BaseApplicationService(IMapper mapper, IBaseService<T> service) : base()
        {
            _mapper = mapper;
            _service = service;
        }

        public async Task Add(TDto entity)
        {
            await _service.Add(_mapper.Map<T>(entity));
        }

        public async Task Delete(Guid id)
        {
            await _service.Delete(_mapper.Map<T>(id));
        }

        public async Task Delete(TDto entity)
        {
            await _service.Delete(_mapper.Map<T>(entity));
        }

        public async Task Update(TDto entity)
        {
            await _service.Update(_mapper.Map<T>(entity));
        }

        public async Task<List<TDto>> List()
        {
            return _mapper.Map<List<TDto>>(await _service.List());
        }

        public async Task<TDto> SelectById(Guid id)
        {
            return _mapper.Map<TDto>(await _service.SelectById(id));
        }

    }
}
