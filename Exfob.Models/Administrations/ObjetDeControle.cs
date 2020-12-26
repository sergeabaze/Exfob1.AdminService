namespace Exfob.Models.Administration
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    

    [Table("ObjetDeControle")]
    public partial class ObjetDeControle
    {
        [Key]
        public int ControleID { get; set; }

        public int? PeriodeID { get; set; }

        public int? TablesID { get; set; }

        public int? TypeOperationID { get; set; }

        public bool? Active { get; set; }

        public virtual PeriodeCloture PeriodeCloture { get; set; }

        public virtual TablesOperation TablesOperation { get; set; }

        public virtual TypeoperationControle TypeoperationControle { get; set; }
    }
}
