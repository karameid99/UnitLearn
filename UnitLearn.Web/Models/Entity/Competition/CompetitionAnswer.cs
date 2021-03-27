using System;
using System.ComponentModel.DataAnnotations.Schema;
using UnitLearn.Web.Models.Entity.Base;

namespace UnitLearn.Web.Models.Entity.Competition
{
    public class CompetitionAnswer : BaseEntity
    {
        public int Id { get; set; }

        public int CompetitionId { get; set; }
        [ForeignKey(nameof(CompetitionId))]
        public Competition Competition { get; set; }
        
        public int CompetitionQuestionId { get; set; }
        [ForeignKey(nameof(CompetitionQuestionId))]
        public CompetitionQuestion CompetitionQuestion { get; set; }

        public string TextAnswer { get; set; }
        
        public bool? TrueOrFalseAnswer { get; set; }
        
        public int? OptionAnswer { get; set; }
        [ForeignKey(nameof(OptionAnswer))]
        public CompetitionQuestionOptions CompetitionQuestionOptions { get; set; }

        public int CompetitionGroupId { get; set; }
        [ForeignKey(nameof(CompetitionGroupId))]
        public CompetitionGroup CompetitionGroup { get; set; }

        public double Grade { get; set; }
        public bool IsCorrectAnswer { get; set; }
    }
}