using System;
using System.ComponentModel.DataAnnotations;

namespace UnitLearn.Web.Models.Entity.Base
{
    public class City
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
    }
}