using System;
using Exfob1.Communs;
using System.ComponentModel.DataAnnotations;
namespace Exfob1.Models.Adminstrations
{
	public  class SocieteMaritimeRequest
	{
		[Required]
		public int  SocieteID { get; set; }
		[Required]
		public string  NomSociete { get; set; }
		public string  ServiceContrat { get; set; }
		public string  Mention { get; set; }
		public double  DelaisAttenteAccostage { get; set; }
	}
}
