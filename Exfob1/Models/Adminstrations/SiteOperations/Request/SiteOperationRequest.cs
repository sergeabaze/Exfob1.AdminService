using System;
using Exfob1.Communs;
using System.ComponentModel.DataAnnotations;
namespace Exfob1.Models.Adminstrations
{
	public  class SiteOperationRequest
	{
		public double  SiegeID { get; set; }
		public int  NatureSiteID { get; set; }
		public double  PaysID { get; set; }
		[Required]
		public string  Code { get; set; }
		[Required]
		public string  Libelle { get; set; }
		public string  Adresse { get; set; }
		public bool  Activite { get; set; }
		public string  PostAff { get; set; }
		public string  Trajet { get; set; }
		public int  SocieteID { get; set; }
	}
}
