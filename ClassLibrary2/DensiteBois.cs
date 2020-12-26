namespace ClassLibrary2
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class DensiteBois
    {
        public int DensiteBoisID { get; set; }

        public int EssenceID { get; set; }

        public int ProduitID { get; set; }

        public float Libelle { get; set; }

        public virtual Essence Essence { get; set; }

        public virtual Produit Produit { get; set; }
    }
}
