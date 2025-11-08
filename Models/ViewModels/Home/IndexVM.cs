// This Code Belong For Diamond Key Software solutions
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PharmacistsSyndicateReNew.Models.ViewModels.Home
{
    public class IndexVM
    {
        public Guid Id { get; set; }
        public Guid MembershipId { get; set; }
        public Guid AccountId { get; set; }

        [Required(ErrorMessage = "يرجى ادخال الاسم الرباعي واللقب")]
        [Display(Name = "الاسم الرباعي واللقب")]
        public required string FullName { get; set; }

        [Required(ErrorMessage = "يرجى ادخال رقم الستجيل رجاءا")]
        [Display(Name = "رقم التسجيل")]
        public required string RegisterNumber { get; set; }

        [Required(ErrorMessage = "يرجى ادخال البريد الالكتروني")]
        [EmailAddress]
        [Display(Name = "البريد الالكتروني المستخدم في استمارة الانتماء")]
        public required string Email { get; set; } = "";

        [Required(ErrorMessage = "يجب تحديد رقم الهاتف رجاءا")]
        [Display(Name = "رقم الهاتف المستخدم في استمارة الانتماء")]
        public string PhoneNumber { get; set; } = "";
    }
}