using System;
namespace Exfob1.Models.Adminstrations
{
	public  class MaterielListe
	{
		public int  MaterielID { get; set; }
		public int  SiteOperationID { get; set; }
		public int  TypeMaterielID { get; set; }
		public string  Code { get; set; }
		public string  Libelle { get; set; }
		public int  SousTraitanceID { get; set; }
	}
}
