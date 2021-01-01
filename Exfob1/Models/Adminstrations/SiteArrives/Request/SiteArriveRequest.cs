using System;
using Exfob1.Communs;
using System.ComponentModel.DataAnnotations;
namespace Exfob1.Models.Adminstrations
{
	public  class SiteArriveRequest
	{
		[Required(ErrorMessage = MessageValidations.Erreur100)]
		public double  PaysID { get; set; }
		[Range(1, int.MaxValue, ErrorMessage = MessageValidations.Erreur100)]
		[Required(ErrorMessage = MessageValidations.Erreur100)]
		public int  NatureSiteID { get; set; }
		[Range(1, int.MaxValue, ErrorMessage = MessageValidations.Erreur100)]
		[Required(ErrorMessage = MessageValidations.Erreur100)]
		public int  PortID { get; set; }
		[Range(1, int.MaxValue, ErrorMessage = MessageValidations.Erreur100)]
		[Required(ErrorMessage = MessageValidations.Erreur100)]
		public int  SocieteID { get; set; }
		[Required(ErrorMessage = MessageValidations.Erreur100)]
		public string  CodePort { get; set; }
		[Required(ErrorMessage = MessageValidations.Erreur100)]
		public string  Libelle { get; set; }
		[Required(ErrorMessage = MessageValidations.Erreur100)]
		public string  Adresse { get; set; }
		public string  Aactif { get; set; }
		public string  Phyto { get; set; }
		public string  Co { get; set; }
		public string  Eur1 { get; set; }
	}
}
