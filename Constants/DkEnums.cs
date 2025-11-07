using System.ComponentModel.DataAnnotations;
using System.Reflection;


namespace PharmacistsSyndicateReNew.Constants
{
    public class DkEnums
    {
        public enum ProfessionalWorkTypes
        {
            [Display(Name = " صاحب إجازة ومسؤولية")]
            HasLicenseAndResponsibility,
            [Display(Name = "إجازة فقط")]
            HasLicense,
            [Display(Name = "مسؤولية فقط")]
            HasResponsibility,
            [Display(Name = "تحت اشراف مسؤول")]
            UnderSupervision,
            [Display(Name = "لا يوجد")]
            Nothing,
        }
        public enum WorkTypes
        {
            [Display(Name = "صيدلية")]
            pharmacy,
            [Display(Name = "مكتب")]
            office,
            [Display(Name = "مذخر")]
            MedicineStore,
            [Display(Name = "مختبر")]
            libratory,
            [Display(Name = "مصنع")]
            factory,
        }
        public enum WorkSchedule
        {
            [Display(Name = "دوام كامل")]
            fullTime,
            [Display(Name = "نصف دوام")]
            halfTime,
            [Display(Name = "خافرة")]
            fullDay,
        }
    }
}

public static class EnumExtensions
{
    /// <summary>
    /// Retrieves the value of the DisplayAttribute.Name property.
    /// </summary>
    public static string GetDisplayName(this Enum enumValue)
    {
        return enumValue.GetType()
                        .GetMember(enumValue.ToString())
                        .First()
                        .GetCustomAttribute<DisplayAttribute>()
                        ?.GetName() ?? enumValue.ToString();
    }
}
