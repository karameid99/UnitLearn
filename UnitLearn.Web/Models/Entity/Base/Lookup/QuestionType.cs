using System;
using System.ComponentModel.DataAnnotations;

namespace UnitLearn.Web.Models.Entity.Base.Lookup
{
    public class QuestionType
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
    }
}