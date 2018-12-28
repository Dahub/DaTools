using System.Collections.Generic;

namespace DaTools.EntityFramework.Core.Interfaces
{
    public interface IRepository<T> where T : IDomainObject
    {
        IContext Context { get; set; }
        T GetById(int id);
        int Add(T toAdd);
        void Update(T toUpdate);
        void Delete(T toDelete);
        IEnumerable<T> GetAll();
    }
}
