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


        public IActionResult Create(MembershipManagementVM model)
        {
            ModelState.Clear();
            return View(model);
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View("Error!");
        }
    }
}