using System;
namespace Exfob1.Models.Adminstrations
{
	public  class PeriodeClotureReponse
	{

		public int  PeriodeID { get; set; }
		public int  SocieteID { get; set; }
		public string  Code { get; set; }
		public string  Libelle { get; set; }
		public bool  EstPeriodeCourante { get; set; }
		public bool  EstPeriodeCloture { get; set; }
		public DateTime  DateDebut { get; set; }
		public DateTime  DateFin { get; set; }
		public string  CreerPar { get; set; }
		public DateTime  DateCreation { get; set; }
		public string  ModifierPar { get; set; }
		public DateTime  DateModification { get; set; }
	}
}
