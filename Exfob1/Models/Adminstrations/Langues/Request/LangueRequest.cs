using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Exfob1.Models.Adminstrations.Langues.Request
{
   public  class LangueRequest
    {
        [Required]
        public string Code { get; set; }

        [Required]
        public string Libelle { get; set; }
    }
}
