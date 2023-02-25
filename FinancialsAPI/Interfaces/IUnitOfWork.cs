using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FinancialsAPI.Interfaces
{
    public interface IUnitOfWork
    {
        ITransaction Transaction { get; }
        IStock Stock { get; }
        Task<bool> SaveAsync();
    }
}
