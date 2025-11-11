// This Code Belong For Diamond Key Software solutions
using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using PharmacistsSyndicateReNew.Constants;
using PharmacistsSyndicateReNew.Core.UnitOfWork;
using PharmacistsSyndicateReNew.implementation.Helper;
using PharmacistsSyndicateReNew.Models;
using PharmacistsSyndicateReNew.Models.ViewModels.Home;
using PharmacistsSyndicateReNew.Models.ViewModels.SyndicateMembershipManagement.Membership;

namespace PharmacistsSyndicateReNew.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private IUnitOfWork _unitOfWork;

    public HomeController(IUnitOfWork unitOfWork, ILogger<HomeController> logger)
    {
        _logger = logger;
        _unitOfWork = unitOfWork;
    }

    public IActionResult Index()
    {
        var model = new IndexVM
        {
            Universities = GetUniqueUniversityList(),

        };
        return View(model);
    }
    [HttpPost]
    public IActionResult Index(IndexVM model)
    {
        try
        {

            if (ModelState.IsValid)
            {
                /// Add MainInformation to database 
                // var mainInformation = new MainInformation();
                // mainInformation.RegisterNumber = model.RegisterNumber;
                // mainInformation.UserFullName = model.FullName;
                // mainInformation.Email = model.Email;
                // mainInformation.PhoneNumber = model.PhoneNumber;
                // mainInformation.University = model.University;
                // mainInformation.LastYearRegistration = "2025";
                // mainInformation.DateIn = DateTime.Now;
                // _unitOfWork.MainInformation.Add(mainInformation);
                // _unitOfWork.Complete();
                int accepted = 0;
                var user = _unitOfWork.MainInformation.SingleOrDefault(e => e.RegisterNumber == model.RegisterNumber);
                if (user != null)
                {
                    var isNameExist = HelperFunction.MatchingStrings(user.UserFullName, model.FullName);
                    var isEmailExist = user.Email.Trim() == model.Email.Trim();
                    var isPhoneNumberExist = user.PhoneNumber.Trim() == model.PhoneNumber.Trim();
                    if (isEmailExist) accepted++;

                    if (isPhoneNumberExist) accepted++;

                    if (isNameExist) accepted++;

                    if (accepted >= 2)
                    {
                        var newModel = new MembershipManagementVM();
                        var nameParts = HelperFunction.ProcessAndSplitArabicName(model.FullName);
                        newModel.Email = model.Email;
                        newModel.PhoneNumber = model.PhoneNumber;
                        newModel.FNameArabic = nameParts.Length > 0 ? nameParts[0] : "";
                        newModel.SNameArabic = nameParts.Length > 1 ? nameParts[1] : "";
                        newModel.ThNameArabic = nameParts.Length > 2 ? nameParts[2] : "";
                        newModel.ForthNameArabic = nameParts.Length > 3 ? nameParts[3] : "";
                        newModel.SurNameArabic = nameParts.Length > 4 ? nameParts[4] : "";
                        newModel.RegisterNumber = model.RegisterNumber ?? "";


                        return RedirectToAction("Create", "SyndicateManagement", newModel);
                    }
                    ModelState.AddModelError(DkStrings.IndexError01, DkStrings.IndexError01);
                    return View(model);
                }
            }
            ModelState.AddModelError(DkStrings.IndexError01, DkStrings.IndexError01);
            return View(model);
        }
        catch (System.Exception)
        {
            ModelState.AddModelError(DkStrings.Error01, DkStrings.Error01);
            return View(model);
        }
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }

    // functions 

    // get university name
    private List<SelectListItem> GetUniqueUniversityList()
    {
        // 1. EFFICIENTLY fetch only the University string, filter out blanks, and get distinct values.

        var uniqueUniversities = _unitOfWork.MainInformation.GetAll()
            .Select(u => u.University)
            .Where(u => !string.IsNullOrWhiteSpace(u)) // Filter out empty or whitespace strings
            .Distinct()
            .OrderBy(u => u) // Sort alphabetically for better user experience
            .ToList();

        // 2. Project the unique names into a List<SelectListItem>
        var universityItems = uniqueUniversities.Select(name => new SelectListItem
        {
            Value = name,       // The University name is the value posted back
            Text = name,        // The University name is the text the user sees
            Selected = false
        }).ToList();

        //Optional: Add a placeholder item
        universityItems.Insert(0, new SelectListItem
        {
            Value = "",
            Text = DkStrings.IndexVMUniversityDisplay01,
            Selected = true,
            Disabled = true
        });

        return universityItems;
    }
}

