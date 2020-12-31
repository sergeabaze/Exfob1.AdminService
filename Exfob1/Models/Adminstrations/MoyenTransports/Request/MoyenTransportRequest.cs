using System;
using Exfob1.Communs;
using System.ComponentModel.DataAnnotations;
namespace Exfob1.Models.Adminstrations
{
	public  class MoyenTransportRequest
	{
		[Required]
		public int  SiteOperationID { get; set; }
		[Required]
		public int  TransporteurtID { get; set; }
		public string  NumeroTracteur { get; set; }
		public string  NumeroRemorque { get; set; }
		public string  Numero { get; set; }
		public string  Chauffeur { get; set; }
	}
}
