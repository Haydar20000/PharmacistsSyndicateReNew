using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PharmacistsSyndicateReNew.Models.Local
{
    public class Departments
    {
        public Guid Id { get; set; }
        public string DepartmentName { get; set; } = "";
        public bool InUse { get; set; }
        public DateTime DateIn { get; set; } = DateTime.Now;
        public Guid UserId { get; set; }
    }
}