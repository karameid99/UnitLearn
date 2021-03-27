using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using UnitLearn.Web.Models.Entity.Base;
using UnitLearn.Web.Models.Entity.Base.Lookup;

namespace UnitLearn.Web.Models.Entity.Auth
{
    public class ApplicationUser : IdentityUser
    {
        public string FullName { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public string Gender { get; set; }

        public int? UserTypeId { get; set; }
        [ForeignKey(nameof(UserTypeId))]
        public UserType UserType { get; set; }

        public int? SpecializationId { get; set; }
        [ForeignKey(nameof(SpecializationId))]
        public Specialization Specialization { get; set; }

        public int? EducationalId { get; set; }
        [ForeignKey(nameof(EducationalId))]
        public Educational Educational { get; set; }

    }
}
