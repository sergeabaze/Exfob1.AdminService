namespace ClassLibrary2
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("AffecterEquipe")]
    public partial class AffecterEquipe
    {
        public int AffecterEquipeID { get; set; }

        public int TrancheHoraireID { get; set; }

        public int OperateurID { get; set; }

        public int EquipeID { get; set; }

        public bool? EstChefEquipe { get; set; }

        [Column(TypeName = "date")]
        public DateTime DateOperation { get; set; }

        public bool EstResponsable { get; set; }

        public virtual Equipe Equipe { get; set; }

        public virtual Operateur Operateur { get; set; }

        public virtual TrancheHoraire TrancheHoraire { get; set; }
    }
}
