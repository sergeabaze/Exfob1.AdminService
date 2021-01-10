using System;
namespace Exfob1.Models.Adminstrations
{
	public  class OperateurReponse
	{

		public int  OperateurID { get; set; }
		public int  SiteOperationID { get; set; }
		public int  TypeOperateurID { get; set; }
		public string  Code { get; set; }
		public string  Libelle { get; set; }
		public bool  EstResponsable { get; set; }
		public int  OperateurGB3ID { get; set; }
		public int  OperateurGBID { get; set; }
	}
}
