using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using UnitLearn.Web.Models.Entity.Auth;

namespace UnitLearn.Web.Models.Entity.Assigmnet
{
    public class AssigmentSubmission
    {
        public int Id { get; set; }

        public int AssignmentId { get; set; }
        [ForeignKey(nameof(AssignmentId))]
        public Assignment Assignment { get; set; }

        public string studentId { get; set; }
        [ForeignKey(nameof(studentId))]
        public ApplicationUser student { get; set; }

        public string Notes { get; set; }

        [ScaffoldColumn(false)]
        public DateTime SubmissionAt { get; set; }
    }
}