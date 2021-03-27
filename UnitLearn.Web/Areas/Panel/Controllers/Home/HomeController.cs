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

        [HttpPost]
        public JsonResult AjaxData([FromBody] dynamic data)
        {
            DataTableHelper d = new DataTableHelper(data);

            var query = new List<dynamic>();
            for (int i = 0; i < 100; i++)
            {
                query.Add(new
                {
                    Id = i + 1,
                    Name = RandomString(),
                    createAt = DateTime.Now.AddDays(i).ToString("MM/dd/yyyy")
                });
            }

            int totalCount = query.Count();

            var items = query.Skip(d.Start).Take(d.Length).ToList();
            var result =
               new
               {
                   draw = d.Draw,
                   recordsTotal = totalCount,
                   recordsFiltered = totalCount,
                   data = items
               };
            return Json(result);
        }

        private static Random random = new Random();

        public static string RandomString()
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            return new string(Enumerable.Repeat(chars, 10)
              .Select(s => s[random.Next(s.Length)]).ToArray());
        }


    }
}
