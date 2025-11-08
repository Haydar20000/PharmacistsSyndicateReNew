// This Code Belong For Diamond Key Software solutions
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PharmacistsSyndicateReNew.Core.Engine;
using PharmacistsSyndicateReNew.Core.Interfaces;
using PharmacistsSyndicateReNew.implementation.EntityConfigurations;
using PharmacistsSyndicateReNew.Models.Domain.Local;

namespace PharmacistsSyndicateReNew.Core.Repositories
{
    public class MainInformationRepository : Repository<MainInformation>, IMainInformation
    {
        public MainInformationRepository(SQLDbContext context) : base(context)
        {
        }
    }
}