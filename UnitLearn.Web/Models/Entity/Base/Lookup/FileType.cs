using System;
using System.ComponentModel.DataAnnotations;

namespace UnitLearn.Web.Models.Entity.Base.Lookup
{
    public class FileType
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
    }
}