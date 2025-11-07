using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace PharmacistsSyndicateReNew.Models.Domain.Identity
{
    public class ApplicationUser : IdentityUser
    {
        public Guid DepartmentId { get; set; }
        public required string UserFullName { get; set; }
        public bool StopAccount { get; set; } = false;
        public DateTime RegisterInDate { get; set; }
        public required string IdNumber { get; set; } // رقم الهوية
        public required string RPhoneNumber { get; set; } // رقم هاتف الموجود في استمارة التسجيل
    }
}