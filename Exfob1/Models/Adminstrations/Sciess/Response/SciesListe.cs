using System;
namespace Exfob1.Models.Adminstrations
{
	public  class SciesListe
	{
		public int  SciesID { get; set; }
		public int  SocieteID { get; set; }
		public string  Libelle { get; set; }
		public string  CodeNature { get; set; }
		public string  Sigle { get; set; }
		public string  CodeProduction { get; set; }
		public double  OrdreOperation { get; set; }
		public bool  OrdreActivite { get; set; }
		public string  ScieOrg { get; set; }
		public string  FamilleProduction { get; set; }
		public string  ScieProduit { get; set; }
		public int  EquipeID { get; set; }
	}
}
