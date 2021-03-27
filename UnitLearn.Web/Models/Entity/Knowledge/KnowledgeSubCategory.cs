using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UnitLearn.Web.Models.Entity.Knowledge
{
    public class KnowledgeSubCategory
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "هذا الحقل مطلوب")]
        public string Name { get; set; }

        public int CategoryId { get; set; }
        [ForeignKey(nameof(KnowledgeSubCategory.CategoryId))]
        public KnowledgeCategory Category { get; set; }
    }
}