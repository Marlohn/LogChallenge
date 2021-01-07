using LogChallenge.Domain.Entities.Generic;
using LogChallenge.Domain.Interfaces.Repositories.Generic;
using LogChallenge.Infra.Data.Contexts;
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

        public Task Add(T entity)
        {
            throw new NotImplementedException();
            /*
            contexto.InitTransacao();
            var id = contexto.Set<TEntidade>().Add(entidade).Entity.Id;
            contexto.SendChanges();
            return id;
            */
        }

        public Task Delete(Guid id)
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

        public Task Delete(T entity)
        {
            throw new NotImplementedException();
            /*
            contexto.InitTransacao();
            contexto.Set<TEntidade>().Remove(entidade);
            contexto.SendChanges();
            */
        }

        public Task<List<T>> List()
        {
            throw new NotImplementedException();
            //return contexto.Set<TEntidade>().ToList();
        }

        public Task<T> SelectById(Guid id)
        {            
            throw new NotImplementedException();
            //return contexto.Set<TEntidade>().Find(id);
        }

        public Task Update(T entity)
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
