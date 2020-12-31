using System;
using System.Text;
using System.Collections.Generic;
using Exfob1.Communs;
using System.ComponentModel.DataAnnotations;
namespace Exfob1.Models.Adminstrations
{
	public  class ParcEdit: ParcRequest
	{
		[Range(1, int.MaxValue, ErrorMessage = MessageValidations.Erreur100)]
		public int ParcID { get; set; }
		List<SiteOperationRequest>  SiteOperattions { get; set; }
		List<LieuTransitRequest>  LieuTransits { get; set; }
	}
}
