using System;
using System.ComponentModel.DataAnnotations;
using UnitLearn.Web.Models.Entity.Base;

namespace UnitLearn.Web.Models.Entity.Knowledge
{
    public class KnowledgeCategory : BaseEntity
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "هذا الحقل مطلوب")]
        public string Name { get; set; }
    }
}