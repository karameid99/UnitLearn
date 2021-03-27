using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using UnitLearn.Web.Models.Entity.Base;

namespace UnitLearn.Web.Models.Entity.Knowledge
{
    public class KnowledgeContent : BaseEntity
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "هذا الحقل مطلوب")]
        public string Title { get; set; }

        public string Body { get; set; }

        [Required(ErrorMessage = "هذا الحقل مطلوب")]
        public int MainCategoryId { get; set; }
        [ForeignKey(nameof(KnowledgeContent.MainCategoryId))]
        public KnowledgeCategory MainCategory { get; set; }
        
        public int? SubCategoryId { get; set; }
        [ForeignKey(nameof(KnowledgeContent.SubCategoryId))]
        public KnowledgeSubCategory SubCategory { get; set; }

    }
}