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
using UnitLearn.Web.Models.Entity.Knowledge;

namespace UnitLearn.Web.Areas.Panel.Controllers
{
    public class KnowledgeCategoryController : BaseController
    {
        public KnowledgeCategoryController(
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
            var query = _dbContext.KnowledgeCategory.ToList();
            int totalCount = query.Count();
            var items = query.Select(x => new
            {
                x.Id,
                x.Name,
                total = _dbContext.KnowledgeSubCategory.Where(c => c.CategoryId == x.Id).Count(),
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
        public async Task<IActionResult> Create(KnowledgeCategory KnowledgeCategory)
        {
            if (ModelState.IsValid)
            {
                _dbContext.Add(KnowledgeCategory);
                await _dbContext.SaveChangesAsync();
                return Json(new
                {
                    status = 1,
                    msg = "s: تمت عملية الاضافة بنجاح",
                    close = 1
                });
            }
            return View(KnowledgeCategory);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var specialty = await _dbContext.KnowledgeCategory.FindAsync(id);
            if (specialty == null)
            {
                return NotFound();
            }
            return View(specialty);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, KnowledgeCategory specialty)
        {
            if (id != specialty.Id)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                try
                {
                    _dbContext.Update(specialty);
                    await _dbContext.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!KnowledgeCategoryExists(specialty.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return Json(new
                {
                    status = 1,
                    msg = "s: تمت عملية التعديل بنجاح",
                    close = 1
                });
            }
            return View(specialty);
        }


        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            KnowledgeCategory KnowledgeCategory = _dbContext.KnowledgeCategory.Single(x => x.Id.Equals(id));

            if (KnowledgeCategory == null)
            {
                return NotFound();
            }
            _dbContext.Remove(KnowledgeCategory);
            _dbContext.SaveChanges();

            return Json(new
            {
                status = 1,
                msg = "s: تمت عملية الحذف بنجاح",
                close = 1
            });
        }

        private bool KnowledgeCategoryExists(int id)
        {
            return _dbContext.KnowledgeCategory.Any(e => e.Id == id);
        }

    }
}
