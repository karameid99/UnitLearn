using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using UnitLearn.Web.Models.Entity.Base;

namespace UnitLearn.Web.Models.Entity.Assigmnet
{
    public class AssigmentFile : BaseEntity
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "هذا الحقل مطلوب")]
        public string FilePath { get; set; }

        [Required(ErrorMessage = "هذا الحقل مطلوب")]
        public string FileName { get; set; }
        
        public int AssignmentId{ get; set; }
        [ForeignKey(nameof(AssignmentId))]
        public Assignment Assignment { get; set; }
    }
}