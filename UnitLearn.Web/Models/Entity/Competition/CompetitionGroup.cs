using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using UnitLearn.Web.Models.Entity.Base;

namespace UnitLearn.Web.Models.Entity.Competition
{
    public class CompetitionGroup : BaseEntity
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "هذا الحقل مطلوب")]
        public string Name { get; set; }

        public string Description { get; set; }

        [Required]
        public int CompetitionId { get; set; }
        [ForeignKey(nameof(CompetitionId))]
        public Competition Competition { get; set; }
    }
}
