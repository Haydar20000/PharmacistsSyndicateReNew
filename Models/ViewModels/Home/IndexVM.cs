// This Code Belong For Diamond Key Software solutions

using System.ComponentModel.DataAnnotations;
using PharmacistsSyndicateReNew.Constants;

namespace PharmacistsSyndicateReNew.Models.ViewModels.Home
{
    public class IndexVM
    {
        public Guid Id { get; set; }
        public Guid MembershipId { get; set; }
        public Guid AccountId { get; set; }

        [Required(ErrorMessage = DkStrings.IndexVMFullNameError)]
        [Display(Name = DkStrings.IndexVMFullNameDisplay)]
        public required string FullName { get; set; }

        [Required(ErrorMessage = DkStrings.IndexVMRegisterNumberError)]
        [Display(Name = DkStrings.IndexVMRegisterNumberDisplay)]
        public required string RegisterNumber { get; set; }

        [Required(ErrorMessage = DkStrings.IndexVMEmailError01)]
        [EmailAddress(ErrorMessage = DkStrings.IndexVMEmailError02)]
        [DataType(DataType.EmailAddress)]
        [Display(Name = DkStrings.IndexVMEmailDisplay)]
        public required string Email { get; set; } = "";

        [Required(ErrorMessage = DkStrings.IndexVMEPhoneNumberError)]
        [Display(Name = DkStrings.IndexVMPhoneNumberDisplay)]
        public string PhoneNumber { get; set; } = "";

        [Required(ErrorMessage = DkStrings.IndexVMUniversityError)]
        [Display(Name = DkStrings.IndexVMUniversityDisplay)]
        public string University { get; set; } = "";
        [Required(ErrorMessage = DkStrings.IndexVMGraduationYearError)]
        [Display(Name = DkStrings.IndexVMGraduationYearDisplay)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime GraduationYear { get; set; } = DateTime.Now;


    }
}