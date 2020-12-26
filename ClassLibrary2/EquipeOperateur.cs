namespace ClassLibrary2
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("EquipeOperateur")]
    public partial class EquipeOperateur
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int OperateurID { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int EquipeID { get; set; }

        public int TypeOperateurID { get; set; }

        public bool EstResponsable { get; set; }

        public virtual Equipe Equipe { get; set; }

        public virtual Operateur Operateur { get; set; }

        public virtual TypeOperateur TypeOperateur { get; set; }
    }
}
