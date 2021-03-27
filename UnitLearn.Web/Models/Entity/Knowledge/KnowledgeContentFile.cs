using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using UnitLearn.Web.Models.Entity.Base;
using UnitLearn.Web.Models.Entity.Base.Lookup;

namespace UnitLearn.Web.Models.Entity.Knowledge
{
    public class KnowledgeContentFile : BaseEntity
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "هذا الحقل مطلوب")]
        public string FilePath { get; set; }
        
        public int ContentId { get; set; }
        [ForeignKey(nameof(KnowledgeContentFile.ContentId))]
        public KnowledgeContent Content { get; set; }

        public int? FileTypeId { get; set; }
        [ForeignKey(nameof(KnowledgeContentFile.FileTypeId))]
        public FileType Type { get; set; }
        
    }
}