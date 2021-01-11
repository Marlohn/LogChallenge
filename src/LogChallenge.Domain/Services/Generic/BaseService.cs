using LogChallenge.Domain.Entities.Generic;
using LogChallenge.Domain.Interfaces.Repositories.Generic;
using LogChallenge.Domain.Interfaces.Services.Generic;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LogChallenge.Domain.Services.Generic
{
    public class BaseService<T> : IBaseService<T> where T : BaseEntity
    {

        protected readonly IBaseRepository<T> _repository;

        public BaseService(IBaseRepository<T> repository)
        {
            _repository = repository;
        }

        public async Task Add(T entity)
        {
            await _repository.Add(entity);
        }

        public async Task Delete(Guid id)
        {
            await _repository.Delete(id);
        }

        public async Task Delete(T entity)
        {
            await _repository.Delete(entity);
        }

        public async Task Update(T entity)
        {
            await _repository.Update(entity);
        }

        public async Task<List<T>> List()
        {
            return await _repository.List();
        }

        public async Task<T> SelectById(Guid id)
        {
            return await _repository.SelectById(id);
        }
    }
}
