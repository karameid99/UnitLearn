using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using UnitLearn.Web.Models.Entity.Auth;
using UnitLearn.Web.Models.Entity.Base;

namespace UnitLearn.Web.Models.Entity.Questionnaire
{
    public class QuestionnaireAnswer : BaseEntity
    {
        public QuestionnaireAnswer()
        {
            AnswerTime = DateTime.Now;
        }
        [Key]
        public int Id { get; set; }
        
        public DateTime AnswerTime { get; set; }

        public int QuestionnaireId { get; set; }
        [ForeignKey(nameof(QuestionnaireId))]
        public Questionnaire Questionnaire { get; set; }
        
        public int QuestionnaireQuestionId { get; set; }
        [ForeignKey(nameof(QuestionnaireQuestionId))]
        public QuestionnaireQuestion QuestionnaireQuestion { get; set; }

        public string TextAnswer { get; set; }
        
        public bool? TrueOrFalseAnswer { get; set; }
        
        public int? QuestionOptionsId { get; set; }
        [ForeignKey(nameof(QuestionOptionsId))]
        public QuestionOptions QuestionOptions { get; set; }

        public string StudentId { get; set; }
        [ForeignKey(nameof(StudentId))]
        public ApplicationUser Student { get; set; }

    }
}