using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using UnitLearn.Web.Models.Entity.Auth;

namespace UnitLearn.Web.Models.Entity.Competition
{
    public class CompetitionMemberGroup
    {
        public int CompetitionGroupId { get; set; }
        [ForeignKey(nameof(CompetitionGroupId))]
        public CompetitionGroup CompetitionGroup { get; set; }

        public string StudentId { get; set; }
        [ForeignKey(nameof(StudentId))]
        public ApplicationUser Student { get; set; }
    }
}
