using System;
using Exfob1.Communs;
using System.ComponentModel.DataAnnotations;
namespace Exfob1.Models.Adminstrations
{
	public  class DroitRequest
	{
		[Required]
		public int  ModuleID { get; set; }
		[Required]
		public int  ProfilID { get; set; }
		[Required]
		public bool  Ecriture { get; set; }
		[Required]
		public bool  Lecture { get; set; }
		[Required]
		public bool  Modifier { get; set; }
		[Required]
		public bool  Suppression { get; set; }
		[Required]
		public bool  Impression { get; set; }
	}
}
