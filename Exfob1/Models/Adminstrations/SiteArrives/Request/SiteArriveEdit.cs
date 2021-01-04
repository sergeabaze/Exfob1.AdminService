using System;
using System.Text;
using System.Collections.Generic;
using Exfob1.Communs;
using System.ComponentModel.DataAnnotations;
namespace Exfob1.Models.Adminstrations
{
	public  class SiteArriveEdit: SiteArriveRequest
	{
		[Range(1, int.MaxValue, ErrorMessage = MessageValidations.Erreur100)]
		public int SiteArriveID { get; set; }
		List<PaysRequest>  Payss { get; set; }
		List<NatureSiteRequest>  NatureSites { get; set; }
		List<PortRequest>  Ports { get; set; }
		List<SocieteRequest>  Societes { get; set; }
	}
}
