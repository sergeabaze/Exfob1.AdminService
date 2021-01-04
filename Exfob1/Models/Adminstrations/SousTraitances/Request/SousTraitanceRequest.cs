using System;
using Exfob1.Communs;
using System.ComponentModel.DataAnnotations;
namespace Exfob1.Models.Adminstrations
{
	public  class SousTraitanceRequest
	{
		[Required]
		public int  SiteOperationID { get; set; }
		[Required]
		public string  Intitule { get; set; }
		public string  SigleTrait { get; set; }
		public string  InfoTrait { get; set; }
		public string  CodeTransp { get; set; }
		public string  SousFacture { get; set; }
	}
}
