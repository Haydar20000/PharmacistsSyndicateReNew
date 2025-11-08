// This Code Belong For Diamond Key Software solutions
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PharmacistsSyndicateReNew.Core.Interfaces;

namespace PharmacistsSyndicateReNew.Core.UnitOfWork
{
    public interface IUnitOfWork : IDisposable
    {
        IMainInformation MainInformation { get; }

        int Complete();

        public void Update(object tEntity);
    }
}