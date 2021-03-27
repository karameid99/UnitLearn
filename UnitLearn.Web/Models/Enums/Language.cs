using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace UnitLearn.Web.Models.Enums
{
    public enum Language
    {
        [Display(Name = "العربية")]
        Ar,
        [Display(Name = "الانجليزية")]
        En,
    }
}
