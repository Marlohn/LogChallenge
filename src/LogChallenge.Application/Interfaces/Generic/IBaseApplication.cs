using LogChallenge.Application.Dto.Generic;
using LogChallenge.Domain.Entities.Generic;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace LogChallenge.Application.Interfaces.Generic
{
    public interface IBaseApplication<T, TDto> where T : BaseEntity where TDto : BaseEntityDto
    {
        Task<Guid> Add(TDto entity);
        Task Delete(Guid id);
        Task Delete(TDto entity);
        Task Update(TDto entity);
        Task<TDto> GetById(Guid id);
        Task<List<TDto>> List();
        Task<IEnumerable<TDto>> Where(Expression<Func<T, bool>> predicate);
    }
}