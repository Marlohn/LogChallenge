using LogChallenge.Domain.Entities.Generic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogChallenge.Domain.Interfaces.Repositories.Generic
{
    public interface IBaseRepository<T> where T : BaseEntity
    {
        Task<Guid> Add(T entity);
        Task Delete(Guid id);
        Task Delete(T entity);
        Task Update(T entity);
        Task<T> SelectById(Guid id);
        Task<List<T>> List();
    }
}
