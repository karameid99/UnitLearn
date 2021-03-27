using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using UnitLearn.Web.Models.Entity.Auth;

namespace UnitLearn.Web.Models.Entity.Mailing
{
    public class Mailing
    {
        public Mailing()
        {
            SendAt = DateTime.Now;
        }

        [Key]
        public int Id { get; set; }

        public string SendFromId { get; set; }
        [ForeignKey(nameof(SendFromId))]
        public ApplicationUser SendFrom { get; set; }

        public string SendToId { get; set; }
        [ForeignKey(nameof(SendToId))]
        public ApplicationUser SendTo { get; set; }

        public string Subject { get; set; }

        public string Body { get; set; }

        public DateTime SendAt { get; set; }
    }
}
