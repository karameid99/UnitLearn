using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using UnitLearn.Web.Models.Entity.Base;

namespace UnitLearn.Web.Models.Entity.Assigmnet
{
    public class Assignment  : BaseEntity
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "هذا الحقل مطلوب")]
        public string Title { get; set; }

        public string Description { get; set; }

        [Required(ErrorMessage = "هذا الحقل مطلوب")]
        [Range(0, float.MaxValue, ErrorMessage = "الرجاء ادخال رقم عشري")]
        public float Mark { get; set; }

        [Required(ErrorMessage = "وقت البداية مطلوب")]
        [DataType(DataType.DateTime, ErrorMessage = "dd/mm/yyyy hh:mm الرجاء ادخال وقت كهذا التنسيق ")]
        public DateTime StartAt { get; set; }

        [Required(ErrorMessage = "وقت النهاية مطلوب")]
        [DataType(DataType.DateTime, ErrorMessage = "dd/mm/yyyy hh:mm الرجاء ادخال وقت كهذا التنسيق ")]
        public DateTime EndAt { get; set; }

        [ScaffoldColumn(false)]
        public bool AllowOverTime { get; set; }

        [Required(ErrorMessage = "هذا الحقل مطلوب")]
        [Range(0, int.MaxValue, ErrorMessage = "الرجاء ادخال رقم صحيح")]
        public int NumberOfAttempt { get; set; }

        public int CourseId { get; set; }
        [ForeignKey(nameof(CourseId))]
        public Course.Course Course { get; set; }
    }
}