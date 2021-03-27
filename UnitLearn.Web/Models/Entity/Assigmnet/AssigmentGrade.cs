using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using UnitLearn.Web.Models.Entity.Assigmnet;
using UnitLearn.Web.Models.Entity.Auth;

namespace UnitLearn.Web.Models.Entity.Assigmnet
{
    public class AssigmentGrade
    {
        public int Id { get; set; }

        public int AssignmentId { get; set; }
        [ForeignKey(nameof(AssignmentId))]
        public Assignment Assignment { get; set; }

        public string studentId { get; set; }
        [ForeignKey(nameof(studentId))]
        public ApplicationUser student { get; set; }

        [Required(ErrorMessage = "هذا الحقل مطلوب")]
        [Range(0, float.MaxValue, ErrorMessage = "الرجاء ادخال رقم عشري")]
        public float Grade { get; set; }

        [ScaffoldColumn(false)]
        public DateTime GradeAt { get; set; }
    }
}