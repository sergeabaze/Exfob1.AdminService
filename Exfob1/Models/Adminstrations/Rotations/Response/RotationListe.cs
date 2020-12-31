using System;
namespace Exfob1.Models.Adminstrations
{
	public  class RotationListe
	{
		public int  RotationID { get; set; }
		public int  SiteOperationID { get; set; }
		public int  EquipeID { get; set; }
		public int  TrancheHoraireID { get; set; }
		public int  SciesID { get; set; }
		public string  Code { get; set; }
		public string  Libelle { get; set; }
		public DateTime  DateCreation { get; set; }
		public DateTime  DateModification { get; set; }
	}
}
