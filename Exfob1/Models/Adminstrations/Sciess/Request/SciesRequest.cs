using System;
using Exfob1.Communs;
using System.ComponentModel.DataAnnotations;
namespace Exfob1.Models.Adminstrations
{
	public  class SciesRequest
	{
		[Required]
		public int  SocieteID { get; set; }
		[Required]
		public string  Libelle { get; set; }
		[Required]
		public string  CodeNature { get; set; }
		public string  Sigle { get; set; }
		[Required]
		public string  CodeProduction { get; set; }
		public double  OrdreOperation { get; set; }
		public bool  OrdreActivite { get; set; }
		public string  ScieOrg { get; set; }
		public string  FamilleProduction { get; set; }
		public string  ScieProduit { get; set; }
		public int  EquipeID { get; set; }
	}
}
