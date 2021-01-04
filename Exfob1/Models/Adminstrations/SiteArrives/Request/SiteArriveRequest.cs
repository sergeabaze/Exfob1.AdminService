using System;
using Exfob1.Communs;
using System.ComponentModel.DataAnnotations;
namespace Exfob1.Models.Adminstrations
{
	public  class SiteArriveRequest
	{
		[Required]
		public double  PaysID { get; set; }
		[Required]
		public int  NatureSiteID { get; set; }
		[Required]
		public int  PortID { get; set; }
		[Required]
		public int  SocieteID { get; set; }
		[Required]
		public string  CodePort { get; set; }
		[Required]
		public string  Libelle { get; set; }
		[Required]
		public string  Adresse { get; set; }
		public string  Aactif { get; set; }
		public string  Phyto { get; set; }
		public string  Co { get; set; }
		public string  Eur1 { get; set; }
	}
}
