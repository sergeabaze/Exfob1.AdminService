using System;
using Exfob1.Communs;
using System.ComponentModel.DataAnnotations;
namespace Exfob1.Models.Adminstrations
{
	public  class ConteneurOrigineRequest
	{
		[Required]
		public int  ContenaireOrigineID { get; set; }
		[Required]
		public string  Libelle { get; set; }
	}
}
