using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using UnitLearn.Web.Models.Entity.Base;

namespace UnitLearn.Web.Models.Entity.Questionnaire
{
    public class Questionnaire : BaseEntity
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "هذا الحقل مطلوب")]
        public string Name { get; set; }

        public string Description { get; set; }

        [Required]
        public int CourseId { get; set; }
        [ForeignKey(nameof(CourseId))]
        public Course.Course Course { get; set; }
        
    }
}