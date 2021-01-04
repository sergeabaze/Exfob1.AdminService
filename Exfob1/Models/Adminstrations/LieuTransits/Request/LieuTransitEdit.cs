using System;
using System.Text;
using System.Collections.Generic;
using Exfob1.Communs;
using System.ComponentModel.DataAnnotations;
namespace Exfob1.Models.Adminstrations
{
	public  class LieuTransitEdit: LieuTransitRequest
	{
		[Range(1, int.MaxValue, ErrorMessage = MessageValidations.Erreur100)]
		public int LieuTransitID { get; set; }
		List<SiteOperationRequest>  SiteOperattions { get; set; }
		List<PortRequest>  Ports { get; set; }
	}
}
