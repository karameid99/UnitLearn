using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using UnitLearn.Web.Models.Entity.Base;
using UnitLearn.Web.Models.Entity.Base.Lookup;

namespace UnitLearn.Web.Models.Entity.Questionnaire
{
    public class QuestionnaireQuestion : BaseEntity
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "هذا الحقل مطلوب")]
        public string Question { get; set; }
        
        public int QuestionnaireId { get; set; }
        [ForeignKey(nameof(QuestionnaireId))]
        public Questionnaire Questionnaire { get; set; }

        public int QuestionTypeId { get; set; }
        [ForeignKey(nameof(QuestionTypeId))]
        public QuestionType QuestionType { get; set; }
        
    }
}