using System;
using Exfob1.Communs;
using System.ComponentModel.DataAnnotations;
namespace Exfob1.Models.Adminstrations
{
	public  class TransporteurRequest
	{
		public int  SiteOperationID { get; set; }
		public int  ModeTransportID { get; set; }
		public int  ComptabiliteID { get; set; }
		public string  Code { get; set; }
		public string  NomTransporteur { get; set; }
		public string  Adresse { get; set; }
		public string  Telephone { get; set; }
		public string  Responsable { get; set; }
		public string  Comptabilite1 { get; set; }
		public string  Comptabilite2 { get; set; }
	}
}
