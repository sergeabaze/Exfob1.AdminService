using System;
namespace Exfob1.Models.Adminstrations
{
	public  class MoyenTransportReponse
	{

		public int  MoyenTransportID { get; set; }
		public int  SiteOperationID { get; set; }
		public int  TransporteurtID { get; set; }
		public string  NumeroTracteur { get; set; }
		public string  NumeroRemorque { get; set; }
		public string  Numero { get; set; }
		public string  Chauffeur { get; set; }
	}
}
