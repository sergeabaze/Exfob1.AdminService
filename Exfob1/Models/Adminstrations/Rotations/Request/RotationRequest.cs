using System;
using Exfob1.Communs;
using System.ComponentModel.DataAnnotations;
namespace Exfob1.Models.Adminstrations
{
	public  class RotationRequest
	{
		[Required]
		public int  SiteOperationID { get; set; }
		[Required]
		public int  EquipeID { get; set; }
		[Required]
		public int  TrancheHoraireID { get; set; }
		[Required]
		public int  SciesID { get; set; }
		[Required]
		public string  Code { get; set; }
		[Required]
		public string  Libelle { get; set; }
		public DateTime  DateCreation { get; set; }
		public DateTime  DateModification { get; set; }
	}
}
