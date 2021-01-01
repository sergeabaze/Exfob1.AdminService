using System;
using Exfob1.Communs;
using System.ComponentModel.DataAnnotations;
namespace Exfob1.Models.Adminstrations
{
	public  class ClientRequest
	{
		[Range(1, int.MaxValue, ErrorMessage = MessageValidations.Erreur100)]
		public int  SiteOperationID { get; set; }
		public double  SiegeID { get; set; }
		[Range(1, int.MaxValue, ErrorMessage = MessageValidations.Erreur100)]
		[Required(ErrorMessage = MessageValidations.Erreur100)]
		public int  TypeclientID { get; set; }
		[Required(ErrorMessage = MessageValidations.Erreur100)]
		public double  PaysID { get; set; }
		[Range(1, int.MaxValue, ErrorMessage = MessageValidations.Erreur100)]
		[Required(ErrorMessage = MessageValidations.Erreur100)]
		public int  VilleID { get; set; }
		public string  Code { get; set; }
		public string  Nomclient { get; set; }
		public string  Telephone1 { get; set; }
		public string  Telephone2 { get; set; }
		public string  Faxe1 { get; set; }
		public string  Faxe2 { get; set; }
		public string  Email { get; set; }
		public string  Observation { get; set; }
		public string  EorNumber { get; set; }
	}
}
