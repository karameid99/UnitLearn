using System;
using System.ComponentModel.DataAnnotations;

namespace UnitLearn.Web.Models.Entity.Base
{
    public class UserType
    {
        [Key]
        public int Id { get; set; }
        public string NameAr  { get; set; }
        public string NameEn { get; set; }
    }
}