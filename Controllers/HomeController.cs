// This Code Belong For Diamond Key Software solutions
using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using PharmacistsSyndicateReNew.Constants;
using PharmacistsSyndicateReNew.Core.UnitOfWork;
using PharmacistsSyndicateReNew.implementation.Helper;
using PharmacistsSyndicateReNew.Models;
using PharmacistsSyndicateReNew.Models.Domain.Local;
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
        return View();
    }
    [HttpPost]
    public IActionResult Index(IndexVM model)
    {
        try
        {
            if (ModelState.IsValid)
            {
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
                        newModel.RegisterNumber = model.RegisterNumber;

                        return RedirectToAction("Create", "SyndicateManagement", newModel);
                    }
                    ModelState.AddModelError(DkStrings.IndexError01, DkStrings.IndexError01);
                    return View(model);
                }
            }
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
}

// we can use to add user for test delete it when project finish
//  var newModel = new MainInformation();
//         newModel.MembershipId = model.MembershipId;
//         newModel.UserFullName = model.FullName;
//         newModel.RegisterNumber = model.RegisterNumber;
//         newModel.DateIn = DateTime.Now;
//         newModel.Email = model.Email;
//         newModel.PhoneNumber = model.PhoneNumber;
//         newModel.MembershipId = Guid.NewGuid();
//         _unitOfWork.MainInformation.Add(newModel);
//         _unitOfWork.Complete();