using System.ComponentModel.DataAnnotations.Schema;

namespace UnitLearn.Web.Models.Entity.Assigmnet
{
    public class AssigmentSubmissionFile
    {
        public int Id { get; set; }
        
        public string FilePath { get; set; }
        
        public int AssigmentSubmissionId { get; set; }
        [ForeignKey(nameof(AssigmentSubmissionId))]
        public AssigmentSubmission AssigmentSubmission { get; set; }
    }
}