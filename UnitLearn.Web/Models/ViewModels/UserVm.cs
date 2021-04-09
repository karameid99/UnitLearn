using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace UnitLearn.Web.Models.ViewModels
{
    public class UserVm
    {
        public string Id { get; set; }
        [Required(ErrorMessage = "هذا الحقل مطلوب")]
        [Display(Name = "الأسم بالكامل")]
        public string FullName { get; set; }
        [Required(ErrorMessage = "هذا الحقل مطلوب")]
        [Display(Name = "البريد الألكتروني")]
        public string Email { get; set; }
        [Required(ErrorMessage = "هذا الحقل مطلوب")]
        [Display(Name = "رقم الهاتف")]
        public string Phone { get; set; }
        [Required(ErrorMessage = "هذا الحقل مطلوب")]
        [Display(Name = "كلمة المرور")]
        public string Password { get; set; }
        [Display(Name = "رقم الهاتف")]
        public DateTime? DateOfBirth { get; set; }
        [Display(Name = "الجنس")]
        public string Gender { get; set; }
        [Display(Name = "رتبة المستخدم")]
        public int? UserTypeId { get; set; }
        [Display(Name = "التخصص")]
        public int? SpecializationId { get; set; }
        [Display(Name = "التعليم")]
        public int? EducationalId { get; set; }
    }
}
