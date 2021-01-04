using System;
using Exfob1.Communs;
using System.ComponentModel.DataAnnotations;
namespace Exfob1.Models.Adminstrations
{
	public  class NavireRequest
	{
		[Required]
		public int  SocieteMaritimeID { get; set; }
		[Required]
		public int  LoadingNavireID { get; set; }
		[Required]
		public string  CodeNavire { get; set; }
		public string  NomNavire { get; set; }
	}
}
