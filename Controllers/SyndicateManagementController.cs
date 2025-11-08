using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PharmacistsSyndicateReNew.Constants;
using PharmacistsSyndicateReNew.Core.UnitOfWork;
using PharmacistsSyndicateReNew.implementation.Helper;
using PharmacistsSyndicateReNew.Models.Domain.Identity;
using PharmacistsSyndicateReNew.Models.ViewModels.Home;
using PharmacistsSyndicateReNew.Models.ViewModels.SyndicateMembershipManagement.Membership;

namespace PharmacistsSyndicateReNew.Controllers
{
    // [Route("[controller]")]
    public class SyndicateManagementController : Controller
    {
        private readonly ILogger<SyndicateManagementController> _logger;
        private IUnitOfWork _unitOfWork;

        public SyndicateManagementController(IUnitOfWork unitOfWork, ILogger<SyndicateManagementController> logger)
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
                            newModel.ThNameArabic = nameParts.Length > 2 ? nameParts[3] : "";
                            newModel.ForthNameArabic = nameParts.Length > 3 ? nameParts[3] : "";
                            newModel.SurNameArabic = nameParts.Length > 4 ? nameParts[4] : "";
                            newModel.RegisterNumber = model.RegisterNumber;

                            // ModelState.AddModelError(DkStrings.Error02, "");
                            RedirectToAction("Create", "SyndicateManagement", newModel);
                        }
                        return View(model);
                    }



                }
                return View(model);
            }
            catch (System.Exception)
            {
                ModelState.AddModelError(DkStrings.Error01, "");
                return View(model);
            }

        }

        public IActionResult Create()
        {
            MembershipManagementVM model = new MembershipManagementVM();
            return View(model);
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View("Error!");
        }
    }
}