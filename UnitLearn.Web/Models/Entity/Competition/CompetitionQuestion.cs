using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using UnitLearn.Web.Models.Entity.Base;
using UnitLearn.Web.Models.Entity.Base.Lookup;

namespace UnitLearn.Web.Models.Entity.Competition
{
    public class CompetitionQuestion : BaseEntity
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "هذا الحقل مطلوب")]
        public string Question { get; set; }

        public int CompetitionId { get; set; }
        [ForeignKey(nameof(CompetitionId))]
        public Competition Competition { get; set; }

        public int QuestionTypeId { get; set; }
        [ForeignKey(nameof(QuestionTypeId))]
        public QuestionType QuestionType { get; set; }

        [Required(ErrorMessage = "هذا الحقل مطلوب")]
        [DefaultValue(0)]
        public int Mark { get; set; }

        [ScaffoldColumn(false)]
        public bool IsActive { get; set; }
    }
}
