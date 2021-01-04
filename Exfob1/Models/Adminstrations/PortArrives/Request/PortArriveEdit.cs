using System;
using System.Text;
using System.Collections.Generic;
using Exfob1.Communs;
using System.ComponentModel.DataAnnotations;
namespace Exfob1.Models.Adminstrations
{
	public  class PortArriveEdit: PortArriveRequest
	{
		[Range(1, int.MaxValue, ErrorMessage = MessageValidations.Erreur100)]
		public int PortArriveID { get; set; }
		List<SocieteRequest>  Societes { get; set; }
		List<SiteArriveRequest>  SiteArrives { get; set; }
	}
}
