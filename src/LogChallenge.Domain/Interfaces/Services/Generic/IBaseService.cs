using LogChallenge.Domain.Entities.Generic;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LogChallenge.Domain.Interfaces.Services.Generic
{
    public interface IBaseService<T> where T : BaseEntity
    {
        Task<Guid> Add(T entity);
        Task Delete(Guid id);
        Task Delete(T entity);
        Task Update(T entity);
        Task<T> GetById(Guid id);
        Task<List<T>> List();
    }
}
