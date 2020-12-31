using System;
using Exfob1.Communs;
using System.ComponentModel.DataAnnotations;
namespace Exfob1.Models.Adminstrations
{
	public  class ModeEnvoieRequest
	{
		[Required]
		public int  SocieteID { get; set; }
		[Required]
		public string  Libelle { get; set; }
	}
}
