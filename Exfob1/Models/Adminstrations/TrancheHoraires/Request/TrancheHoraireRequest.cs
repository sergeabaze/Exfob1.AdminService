using System;
using Exfob1.Communs;
using System.ComponentModel.DataAnnotations;
namespace Exfob1.Models.Adminstrations
{
	public  class TrancheHoraireRequest
	{
		[Required]
		public DateTime  DateDebut { get; set; }
		[Required]
		public DateTime  Datefin { get; set; }
		public string  Libelle { get; set; }
	}
}
