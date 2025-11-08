using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using PharmacistsSyndicateReNew.Constants;

namespace PharmacistsSyndicateReNew.Models.ViewModels.SyndicateMembershipManagement.Membership
{
    public class MembershipManagementVM
    {
        public Guid Id { get; set; }
        public Guid AccountId { get; set; }
        public string RegisterNumber { get; set; } = "";

        [Required(ErrorMessage = DkStrings.MembershipManagementVMFNameArabicError)]
        [Display(Name = DkStrings.MembershipManagementVMFNameArabicDisplay)]
        public string FNameArabic { get; set; } = "";

        [Required(ErrorMessage = DkStrings.MembershipManagementVMSNameArabicError)]
        [Display(Name = DkStrings.MembershipManagementVMSNameArabicDisplay)]
        public string SNameArabic { get; set; } = "";
        [Required(ErrorMessage = DkStrings.MembershipManagementVMThNameArabicError)]
        [Display(Name = DkStrings.MembershipManagementVMThNameArabicDisplay)]
        public string ThNameArabic { get; set; } = "";
        [Required(ErrorMessage = DkStrings.MembershipManagementVMForthNameArabicError)]
        [Display(Name = DkStrings.MembershipManagementVMForthNameArabicDisplay)]
        public string ForthNameArabic { get; set; } = "";

        [Required(ErrorMessage = DkStrings.MembershipManagementVMSurNameArabicError)]
        [Display(Name = DkStrings.MembershipManagementVMSurNameArabicDisplay)]
        public string SurNameArabic { get; set; } = "";

        [Required(ErrorMessage = DkStrings.MembershipManagementVMMotherNameArabicError)]
        [Display(Name = DkStrings.MembershipManagementVMMotherNameArabicDisplay)]
        public string MotherNameArabic { get; set; } = "";

        [Required(ErrorMessage = DkStrings.MembershipManagementVMFNameEnglishError)]
        [Display(Name = DkStrings.MembershipManagementVMFNameEnglishDisplay)]
        public string FNameEnglish { get; set; } = "";

        [Required(ErrorMessage = DkStrings.MembershipManagementVMSNameEnglishError)]
        [Display(Name = DkStrings.MembershipManagementVMSNameEnglishDisplay)]
        public string SNameEnglish { get; set; } = "";

        [Required(ErrorMessage = DkStrings.MembershipManagementVMThNameEnglishError)]
        [Display(Name = DkStrings.MembershipManagementVMThNameEnglishDisplay)]
        public string ThNameEnglish { get; set; } = "";
        [Required(ErrorMessage = DkStrings.MembershipManagementVMSurNameEnglishError)]
        [Display(Name = DkStrings.MembershipManagementVMSurNameEnglishDisplay)]
        public string SurNameEnglish { get; set; } = "";

        [Required(ErrorMessage = DkStrings.MembershipManagementVMMotherNameEnglishError)]
        [Display(Name = DkStrings.MembershipManagementVMMotherNameEnglishDisplay)]
        public string MotherNameEnglish { get; set; } = "";

        [Required(ErrorMessage = DkStrings.PhoneNumberError)]
        [Display(Name = DkStrings.PhoneNumber)]
        public string PhoneNumber { get; set; } = "";

        [Required(ErrorMessage = DkStrings.IndexVMEmailError01)]
        [EmailAddress(ErrorMessage = DkStrings.IndexVMEmailError02)]
        [DataType(DataType.EmailAddress)]
        [Display(Name = DkStrings.IndexVMEmailDisplay)]
        public string Email { get; set; } = "";

        [Required(ErrorMessage = DkStrings.MembershipManagementVMGovernorateError)]
        [Display(Name = DkStrings.MembershipManagementVMGovernorateDisplay)]
        public string Governorate { get; set; } = "";

        [Required(ErrorMessage = DkStrings.MembershipManagementVMCityError)]
        [Display(Name = DkStrings.MembershipManagementVMCityDisplay)]
        public string City { get; set; } = "";

        [Required(ErrorMessage = DkStrings.MembershipManagementVMNeighborhoodError)]
        [Display(Name = DkStrings.MembershipManagementVMNeighborhoodDisplay)]
        public string Neighborhood { get; set; } = "";

        [Required(ErrorMessage = DkStrings.MembershipManagementVMStreetError)]
        [Display(Name = DkStrings.MembershipManagementVMStreetDisplay)]
        public string Street { get; set; } = "";

        [Required(ErrorMessage = DkStrings.MembershipManagementVMHomeError)]
        [Display(Name = DkStrings.MembershipManagementVMHomeDisplay)]
        public string Home { get; set; } = "";
    }
}