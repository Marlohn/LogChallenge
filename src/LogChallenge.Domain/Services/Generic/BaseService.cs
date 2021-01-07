using LogChallenge.Domain.Entities.Generic;
using LogChallenge.Domain.Interfaces.Repositories.Generic;
using LogChallenge.Domain.Interfaces.Services.Generic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogChallenge.Domain.Services.Generic
{
    public class BaseService<T> : IBaseService<T> where T : BaseEntity
    {

        protected readonly IBaseRepository<T> _Repository;

        public BaseService(IBaseRepository<T> Repository)
        {
            _Repository = Repository;
        }

        public async Task Add(T entity)
        {
            await _Repository.Add(entity);
        }

        public async Task Delete(Guid id)
        {
            await _Repository.Delete(id);
        }

        public async Task Delete(T entity)
        {
            await _Repository.Delete(entity);
        }

        public async Task Update(T entity)
        {
            await _Repository.Update(entity);
        }

        public async Task<List<T>> List()
        {
            return await _Repository.List();
        }

        public async Task<T> SelectById(Guid id)
        {
            return await _Repository.SelectById(id);
        }

    }
}
