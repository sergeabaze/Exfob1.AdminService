using System;
using Exfob1.Communs;
using System.ComponentModel.DataAnnotations;
namespace Exfob1.Models.Adminstrations
{
	public  class PeriodeClotureRequest
	{
		[Required]
		public int  PeriodeID { get; set; }
		[Required]
		public int  SocieteID { get; set; }
		[Required]
		public string  Code { get; set; }
		[Required]
		public string  Libelle { get; set; }
		[Required]
		public bool  EstPeriodeCourante { get; set; }
		[Required]
		public bool  EstPeriodeCloture { get; set; }
		[Required]
		public DateTime  DateDebut { get; set; }
		[Required]
		public DateTime  DateFin { get; set; }
		[Required]
		public string  CreerPar { get; set; }
		[Required]
		public DateTime  DateCreation { get; set; }
		public string  ModifierPar { get; set; }
		public DateTime  DateModification { get; set; }
	}
}
