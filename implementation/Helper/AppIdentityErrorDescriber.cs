using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace PharmacistsSyndicateReNew.implementation.Helper
{
    public class AppIdentityErrorDescriber : IdentityErrorDescriber
    {
        public override IdentityError PasswordRequiresUpper()
        {
            return new IdentityError
            {
                Code = nameof(PasswordRequiresUpper),
                Description = "كلمة السر يجب ان تحتوي على حرف كبير واحد على الاقل"
            };
        }

        public override IdentityError PasswordRequiresDigit()
        {
            return new IdentityError
            {
                Code = nameof(PasswordRequiresDigit),
                Description = "كلمة السر يجب ان تحتوي على رقم واحد على الاقل"
            };
        }
    }
}