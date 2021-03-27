using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using UnitLearn.Web.Models.Entity.Auth;

namespace UnitLearn.Web.Models.Entity.Base
{
    public class UserType
    {
        [Key]
        public int Id { get; set; }
        public string NameAr  { get; set; }
        public string NameEn { get; set; }
        public List<ApplicationUser> Users { get; set; }
    }
}