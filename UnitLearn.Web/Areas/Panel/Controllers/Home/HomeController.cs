using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UnitLearn.Web.Data;
using UnitLearn.Web.Helper;
using UnitLearn.Web.Models.Entity.Auth;

namespace UnitLearn.Web.Areas.Panel.Controllers.Home
{
    public class HomeController : BaseController
    {
        public HomeController(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager, ApplicationDbContext dbContext) : base(userManager, roleManager, dbContext)
        {
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Create()
        {
            return View();
        }

       


    }
}
