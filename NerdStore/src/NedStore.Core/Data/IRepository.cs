using System;
using NedStore.Core.DomainObjects;

namespace NerdStore.Core.Data
{
    public interface IRepository<T> : IDisposable where T : IAggregateRoot
    {
        IUnitOfWork UnitOfWork { get; }
    }
}