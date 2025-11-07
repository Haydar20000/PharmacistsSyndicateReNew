using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PharmacistsSyndicateReNew.Models.ViewModels.SyndicateMembershipManagement.Membership
{
    public class MembershipManagementVM
    {
        public Guid Id { get; set; }
        public Guid MembershipId { get; set; }
        public Guid AccountId { get; set; }

        [Required(ErrorMessage = "يجب تحديد الاسم الاول رجاءا")]
        [Display(Name = "الاسم الاول")]
        public string FNameArabic { get; set; }

        [Required(ErrorMessage = "يجب تحديد الاسم الثالث رجاءا")]
        [Display(Name = "الاسم الثاني")]
        public string SNameArabic { get; set; }

        [Required(ErrorMessage = "يجب تحديد الاسم الثالث رجاءا")]
        [Display(Name = "الاسم الثالث")]
        public string ThNameArabic { get; set; }

        [Display(Name = " اللقب")]
        public string SurNameArabic { get; set; }

        [Required(ErrorMessage = "يجب تحديد اسم الام رجاءا")]
        [Display(Name = "اسم الام")]
        public string MotherNameArabic { get; set; }

        [Required(ErrorMessage = "First Name Required Please ")]
        [Display(Name = "First Name")]
        public string FNameEnglish { get; set; }

        [Required(ErrorMessage = "Second Name Required Please ")]
        [Display(Name = "Second Name")]
        public string SNameEnglish { get; set; }

        [Required(ErrorMessage = "Third Name Required Please ")]
        [Display(Name = "Third Name")]
        public string ThNameEnglish { get; set; }

        [Display(Name = "Surname")]
        public string SurNameEnglish { get; set; }

        [Required(ErrorMessage = "Mother Name Required Please ")]
        [Display(Name = "Mother Name")]
        public string MotherNameEnglish { get; set; }

        [Required(ErrorMessage = "يجب تحديد رقم الهاتف رجاءا")]
        [Display(Name = "رقم الهاتف")]
        public string PhoneNumber { get; set; }

        //[Required(ErrorMessage = "يجب تحديد رقم هاتف زين كاش رجاءا")]
        [Display(Name = "رقم هاتف زين كاش")]
        public string PaymentPhoneNumber { get; set; }

        [Display(Name = "البريد الاكتروني")]
        public string Email { get; set; }

        [Required(ErrorMessage = "يجب تحديد المحافظة")]
        [Display(Name = "المحافظة")]
        public string Governorate { get; set; }

        [Required(ErrorMessage = "يجب تحديد المدينة")]
        [Display(Name = "المدينة")]
        public string City { get; set; }

        [Required(ErrorMessage = "يجب تحديد رقم المحلة")]
        [Display(Name = "رقم المحلة")]
        public string Neighborhood { get; set; }

        [Required(ErrorMessage = "يجب تحديد رقم الزقاق")]
        [Display(Name = "رقم الزقاق")]
        public string Street { get; set; }

        [Required(ErrorMessage = "يجب تحديد رقم الدار")]
        [Display(Name = "رقم الدار")]
        public string Home { get; set; }

        [Display(Name = "هل انت موظف؟")]
        public bool IsEmployee { get; set; }

        [Display(Name = "الاسم باللغة العربية")]
        public string FullArabicName { get; set; }

        [Display(Name = "Name in English")]
        public string FullEnglishName { get; set; }
    }
}