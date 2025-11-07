using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PharmacistsSyndicateReNew.Models.Domain.Identity;
using PharmacistsSyndicateReNew.Models.ViewModels.SyndicateMembershipManagement.Membership;

namespace PharmacistsSyndicateReNew.Controllers
{
    // [Route("[controller]")]
    public class SyndicateManagementController : Controller
    {
        private readonly ILogger<SyndicateManagementController> _logger;
        private UserManager<ApplicationUser> _userManager;

        public SyndicateManagementController(UserManager<ApplicationUser> userManager, ILogger<SyndicateManagementController> logger)
        {
            _logger = logger;
            _userManager = userManager;
        }

        public IActionResult Index()
        {
            return View();
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