using System;
using Exfob1.Communs;
using System.ComponentModel.DataAnnotations;
namespace Exfob1.Models.Adminstrations
{
	public  class AffecterEquipeRequest
	{
		[Required]
		public int  TrancheHoraireID { get; set; }
		[Required]
		public int  OperateurID { get; set; }
		[Required]
		public int  EquipeID { get; set; }
		public bool  EstChefEquipe { get; set; }
		[Required]
		public DateTime  DateOperation { get; set; }
		[Required]
		public bool  EstResponsable { get; set; }
	}
}
