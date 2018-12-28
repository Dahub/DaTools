using System;

namespace DaTools.EntityFramework.Core.Interfaces
{
    public interface IContext : IDisposable
    {
        void Commit();
        void CommitAsync();
    }
}
