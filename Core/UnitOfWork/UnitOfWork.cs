// This Code Belong For Diamond Key Software solutions
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PharmacistsSyndicateReNew.Core.Interfaces;
using PharmacistsSyndicateReNew.Core.Repositories;
using PharmacistsSyndicateReNew.implementation.EntityConfigurations;
using PharmacistsSyndicateReNew.Models.Domain.Local;

namespace PharmacistsSyndicateReNew.Core.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private SQLDbContext _context;

        public IMainInformation MainInformation { get; private set; }


        public UnitOfWork(SQLDbContext context)
        {
            _context = context;
            MainInformation = new MainInformationRepository(_context);
        }

        public void Update(object tEntity)
        {
            _context.Entry(tEntity).State = EntityState.Modified;
        }
        public int Complete()
        {
            return _context.SaveChanges();
        }
        public void Dispose()
        {
            _context.Dispose();
        }
    }
}