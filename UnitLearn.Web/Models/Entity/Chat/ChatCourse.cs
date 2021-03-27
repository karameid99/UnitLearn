using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using UnitLearn.Web.Models.Entity.Base;

namespace UnitLearn.Web.Models.Entity.Chat
{
    public class ChatCourse : BaseEntity
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "هذا الحقل مطلوب")]
        public string Name { get; set; }

        [Required(ErrorMessage = "هذا الحقل مطلوب")]
        public int CourseId { get; set; }
        [ForeignKey(nameof(CourseId))]
        public Course.Course Course { get; set; }

        [Range(0, int.MaxValue, ErrorMessage = "الرجاء ادخال رقم صحيح")]
        public int? NumberOfMember { get; set; }

    }
}
