using System;
namespace Exfob1.Models.Adminstrations
{
	public  class TrancheHoraireReponse
	{

		public int  TrancheHoraireID { get; set; }
		public DateTime  DateDebut { get; set; }
		public DateTime  Datefin { get; set; }
		public string  Libelle { get; set; }
	}
}
