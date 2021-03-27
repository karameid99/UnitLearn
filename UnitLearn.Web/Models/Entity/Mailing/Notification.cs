using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using UnitLearn.Web.Models.Entity.Auth;

namespace UnitLearn.Web.Models.Entity.Mailing
{
    public class Notification
    {
        public Notification()
        {
            SendAt = DateTime.Now;
        }
        [Key]
        public int Id { get; set; }

        public string Title { get; set; }

        public string Body { get; set; }

        public DateTime SendAt { get; set; }

        public string SendToId { get; set; }
        [ForeignKey(nameof(SendToId))]
        public ApplicationUser SendTo { get; set; }

        public string Action { get; set; } = "General";
    }
}
