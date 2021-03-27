using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using UnitLearn.Web.Models.Entity.Auth;

namespace UnitLearn.Web.Models.Entity.Course
{
    public class CourseStudent
    {
        [Required]
        public string StudentId { get; set; }
        [ForeignKey(nameof(StudentId))]
        public ApplicationUser Student { get; set; }
        
        public int CourseId { get; set; }
        [ForeignKey(nameof(CourseId))]
        public Course Course { get; set; }

    }
}