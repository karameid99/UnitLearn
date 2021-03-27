using System.ComponentModel.DataAnnotations.Schema;

namespace UnitLearn.Web.Models.Entity.Questionnaire
{
    public class QuestionOptions
    {
        public int Id { get; set; }
        
        public string Option { get; set; }

        public int QuestionId { get; set; }
        [ForeignKey(nameof(QuestionId))]
        public QuestionnaireQuestion QuestionnaireQuestion { get; set; }

    }
    
}