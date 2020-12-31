using System;
namespace Exfob1.Models.Adminstrations
{
	public  class SocieteMaritimeReponse
	{

		public int  SocieteMaritimeID { get; set; }
		public int  SocieteID { get; set; }
		public string  NomSociete { get; set; }
		public string  ServiceContrat { get; set; }
		public string  Mention { get; set; }
		public double  DelaisAttenteAccostage { get; set; }
	}
}
