using System;
using Exfob1.Communs;
using System.ComponentModel.DataAnnotations;
namespace Exfob1.Models.Adminstrations
{
	public  class SiteAutoriseRequest
	{
		[Required]
		public int  SiteOperationID { get; set; }
		[Required]
		public int  UtilisateurID { get; set; }
		[Required]
		public int  ProfilAutoriseID { get; set; }
	}
}
