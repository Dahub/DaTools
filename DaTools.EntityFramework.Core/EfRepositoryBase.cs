using DaTools.EntityFramework.Core.Interfaces;
using System;
using System.Linq;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace DaTools.EntityFramework.Core
{
    public abstract class EfRepositoryBase<T, U> : IRepository<T>
        where T : class, IDomainObject
        where U : DbContext
    {
        IContext IRepository<T>.Context { get; set; }
        public U Context { get; set; }

        public virtual int Add(T toAdd)
        {
            Context.Set<T>().Add(toAdd);
            return toAdd.Id;
        }

        public virtual void Delete(T toDelete)
        {
            Context.Set<T>().Remove(toDelete);
            Context.Entry(toDelete).State = EntityState.Deleted;
        }

        public virtual T GetById(int id)
        {
            return Context.Set<T>().
               Where(c => c.Id.Equals(id)).FirstOrDefault();
        }

        public virtual void Update(T toUpdate)
        {
            Context.Set<T>().Attach(toUpdate);
            Context.Entry(toUpdate).State = EntityState.Modified;
        }

        public virtual IEnumerable<T> GetAll()
        {
            return Context.Set<T>();
        }
    }
}
