using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPatterns.UnitOfWork
{
    public interface IUnitOfWork : IDisposable
    {
        IPersonRepository PersonRepository { get; }
        int Complete();
    }
}
