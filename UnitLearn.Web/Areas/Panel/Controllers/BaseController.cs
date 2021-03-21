using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Controllers;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UnitLearn.Web.Models.Entity.Auth;

namespace UnitLearn.Web.Areas.Panel.Controllers
{
    [Area("Panel")]
    [Route("Panel/[controller]/[action]")]
    [Route("Panel/[controller]/[action]/{id?}")]
    public class BaseController : Controller
    {
        protected readonly UserManager<ApplicationUser> _userManager;
        protected readonly RoleManager<IdentityRole> _roleManager;
        protected String UserId;
        protected String UserName;
        protected String UserType;

        public BaseController(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
        }

        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            var actionName = ((ControllerActionDescriptor)filterContext.ActionDescriptor).ActionName.ToString().ToLower();
            var controllerName = ((ControllerActionDescriptor)filterContext.ActionDescriptor).ControllerName.ToString().ToLower();
         
            if (User.Identity.IsAuthenticated)
            {
                base.OnActionExecuting(filterContext);
                try
                {
                    UserId = _userManager.GetUserId(HttpContext.User);
                    var user = _userManager.Users.SingleOrDefault(x => x.Id.Equals(UserId));
                    UserName = user.UserName;
                    ViewBag.UserId = UserId;
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
        }

        public ApplicationUser GetUser()
        {
            var user = _userManager.Users.SingleOrDefault(x => x.Id.Equals(UserId));
            return user;
        }


    }


}
