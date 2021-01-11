using LogChallenge.Domain.Entities.Generic;
using LogChallenge.Domain.Interfaces.Repositories.Generic;
using LogChallenge.Infra.Data.Contexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LogChallenge.Infra.Data.Repositories.Generic
{
    public class BaseRepository<T> : IBaseRepository<T> where T : BaseEntity
    {
        protected readonly Context _Context;

        public BaseRepository(Context Context) : base()
        {
            _Context = Context;
        }

        public async Task Add(T entity)
        {
            throw new NotImplementedException();
            /*
            contexto.InitTransacao();
            var id = contexto.Set<TEntidade>().Add(entidade).Entity.Id;
            contexto.SendChanges();
            return id;
            */
        }

        public async Task Delete(Guid id)
        {
            throw new NotImplementedException();
            /*
            var entidade = SelecionarPorId(id);
            if (entidade != null)
            {
                contexto.InitTransacao();
                contexto.Set<TEntidade>().Remove(entidade);
                contexto.SendChanges();
            }
            */
        }

        public async Task Delete(T entity)
        {
            throw new NotImplementedException();
            /*
            contexto.InitTransacao();
            contexto.Set<TEntidade>().Remove(entidade);
            contexto.SendChanges();
            */
        }

        public async Task<List<T>> List()
        {
            return await _Context.Set<T>().ToListAsync();
        }

        public async Task<T> SelectById(Guid id)
        {
            throw new NotImplementedException();
            //return contexto.Set<TEntidade>().Find(id);
        }

        public async Task Update(T entity)
        {
            throw new NotImplementedException();
            /*
            contexto.InitTransacao();
            contexto.Set<TEntidade>().Attach(entidade);
            contexto.Entry(entidade).State = EntityState.Modified;
            contexto.SendChanges();
            */
        }
    }
}
