using System;
namespace Exfob1.Models.Adminstrations
{
	public  class FournisseurReponse
	{

		public int  FournisseurID { get; set; }
		public int  SiteOperationID { get; set; }
		public int  TypeFournisseurID { get; set; }
		public string  Code { get; set; }
		public string  Designation { get; set; }
		public string  Adresse1 { get; set; }
		public string  Adresse2 { get; set; }
		public string  BoitePostal { get; set; }
		public string  Telephone1 { get; set; }
		public string  Telephone2 { get; set; }
		public string  Email { get; set; }
	}
}
