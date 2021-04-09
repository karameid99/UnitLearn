using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UnitLearn.Web.Data;
using UnitLearn.Web.Helper;
using UnitLearn.Web.Models.Entity.Auth;
using UnitLearn.Web.Models.ViewModels;

namespace UnitLearn.Web.Areas.Panel.Controllers.Users
{
    public class UserController : BaseController
    {
        public UserController(
           UserManager<ApplicationUser> userManager,
           RoleManager<IdentityRole> roleManager,
           ApplicationDbContext dbContext) : base(userManager, roleManager, dbContext)
        {
        }

        public IActionResult Index()
        {
            return View();
        }
        public JsonResult AjaxData([FromBody] dynamic data)
        {
            DataTableHelper d = new DataTableHelper(data);
            var query = _dbContext.Users.Include(x => x.Specialization).Include(x => x.UserType).Include(x => x.Educational).ToList();
            int totalCount = query.Count();
            var items = query.Select(x => new
            {
                x.Id,
                FullName = x.FullName,
                x.Email,
                Phone = x.PhoneNumber,
                DateOfBirth = x.DateOfBirth?.ToString("dd/MM/yyyy") ?? "-",
                Educational = x.Educational?.Name ?? "-",
                Specialization = x.Specialization?.Name ?? "-",
                UserType = x.UserType?.NameAr ?? "-",
            }).Skip(d.Start).Take(d.Length).ToList();
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
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(UserVm userVm)
        {
            if (ModelState.IsValid && !UserEmailExists(userVm.Email))
            {
                ApplicationUser user = new ApplicationUser
                {
                    Email = userVm.Email,
                    UserName = userVm.Email,
                    DateOfBirth = userVm.DateOfBirth,
                    PhoneNumber = userVm.Phone,
                    SpecializationId = userVm.SpecializationId,
                    EducationalId = userVm.EducationalId,
                    UserTypeId = userVm.UserTypeId,
                    FullName = userVm.FullName,
                    Gender = userVm.Gender,
                };
                var result = await _userManager.CreateAsync(user, userVm.Password);
                if (result.Succeeded)
                {
                    return Content(ResultMessage.AddSuccessResult());
                }
            }
            return View(userVm);
        }
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var userVm = await _dbContext.Users.FindAsync(id);
            if (userVm == null)
            {
                return NotFound();
            }

            return View(new UserVm
            {
                Id = userVm.Id,
                Email = userVm.Email,
                DateOfBirth = userVm.DateOfBirth,
                Phone = userVm.PhoneNumber,
                SpecializationId = userVm.SpecializationId,
                EducationalId = userVm.EducationalId,
                UserTypeId = userVm.UserTypeId,
                FullName = userVm.FullName,
                Gender = userVm.Gender,
            });
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, UserVm userVm)
        {
            if (ModelState.IsValid && id != null)
            {
                try
                {
                    var user = await _dbContext.Users.FindAsync(id);
                    if (user != null && !_dbContext.Users.Any(x => x.Email == user.Email && !x.Id.Equals(user.Id)))
                    {
                        user.Email = userVm.Email;
                        user.UserName = userVm.Email;
                        user.DateOfBirth = userVm.DateOfBirth;
                        user.PhoneNumber = userVm.Phone;
                        user.SpecializationId = userVm.SpecializationId;
                        user.EducationalId = userVm.EducationalId;
                        user.UserTypeId = userVm.UserTypeId;
                        user.FullName = userVm.FullName;
                        user.Gender = userVm.Gender;
                        _dbContext.Users.Update(user);
                        await _dbContext.SaveChangesAsync();
                        return Content(ResultMessage.EditSuccessResult());
                    }
                    else
                    {
                        return Content(ResultMessage.AreadyExsitResult());
                    }
                }
                catch (DbUpdateConcurrencyException)
                {
                    return Content(ResultMessage.FailedResult());
                }
            }
            return View(userVm);
        }
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var user = await _dbContext.Users.FindAsync(id);

            if (user == null)
            {
                return Content(ResultMessage.FailedResult());
            }
            _dbContext.Remove(user);
            await _dbContext.SaveChangesAsync();
            return Content(ResultMessage.DeleteSuccessResult());
        }
        private bool UserEmailExists(string email)
        {
            return _dbContext.Users.Any(e => e.Email == email);
        }
    }
}
