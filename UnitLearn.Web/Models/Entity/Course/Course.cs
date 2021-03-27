using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using UnitLearn.Web.Models.Entity.Auth;
using UnitLearn.Web.Models.Entity.Base;

namespace UnitLearn.Web.Models.Entity.Course
{
    public class Course : BaseEntity
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "هذا الحقل مطلوب")]
        public string Name { get; set; }
        
        public string Description { get; set; }

        [Range(0, int.MaxValue, ErrorMessage = "الرجاء ادخال رقم صحيح")]
        public int? limitStudent { get; set; }

        [Required]
        public string TeacherId { get; set; }
        [ForeignKey(nameof(TeacherId))]
        public ApplicationUser Teacher { get; set; }
    }
}