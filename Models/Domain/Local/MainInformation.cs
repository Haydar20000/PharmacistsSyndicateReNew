// This Code Belong For Diamond Key Software solutions
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PharmacistsSyndicateReNew.Models.Domain.Local
{
    public class MainInformation
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public Guid MembershipId { get; set; } = Guid.NewGuid();
        public string UserFullName { get; set; } = "";
        public string RegisterNumber { get; set; } = "";
        public string Email { get; set; } = "";
        public string PhoneNumber { get; set; } = "";
        public string University { get; set; } = "";
        public string LastYearRegistration { get; set; } = "";
        public DateTime DateIn { get; set; } = DateTime.Now;
    }
}