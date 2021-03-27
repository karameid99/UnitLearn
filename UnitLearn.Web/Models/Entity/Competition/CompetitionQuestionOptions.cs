using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using UnitLearn.Web.Models.Entity.Base;

namespace UnitLearn.Web.Models.Entity.Competition
{
    public class CompetitionQuestionOptions : BaseEntity
    {
        public int Id { get; set; }

        public string Option { get; set; }

        public int CompetitionQuestionId { get; set; }
        [ForeignKey(nameof(CompetitionQuestionId))]
        public CompetitionQuestion CompetitionQuestion { get; set; }

        [Range(0, int.MaxValue, ErrorMessage = "الرجاء ادخال رقم صحيح")]
        public int AnswerNumber { get; set; }
    }

}