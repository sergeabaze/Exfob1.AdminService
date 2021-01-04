using System;
namespace Exfob1.Models.Adminstrations
{
	public  class CodificationListe
	{
		public int  CodificationID { get; set; }
		public int  SiteOperationID { get; set; }
		public string  Code { get; set; }
		public string  Libelle { get; set; }
		public string  QualiteCode { get; set; }
		public string  ClasseCode { get; set; }
	}
}
