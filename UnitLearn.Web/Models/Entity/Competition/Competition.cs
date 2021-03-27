using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using UnitLearn.Web.Models.Entity.Base;

namespace UnitLearn.Web.Models.Entity.Competition
{
    public class Competition : BaseEntity
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "هذا الحقل مطلوب")]
        public string Name { get; set; }

        public string Description { get; set; }

        [Required(ErrorMessage = "هذا الحقل مطلوب")]
        public int CourseId { get; set; }
        [ForeignKey(nameof(CourseId))]
        public Course.Course Course { get; set; }

        public int TotalMark { get; set; }

        public float PassPercentage { get; set; }

        public bool IsActive { get; set; }
    }
}
