using System;
using System.Text;
using System.Collections.Generic;
using Exfob1.Communs;
using System.ComponentModel.DataAnnotations;
namespace Exfob1.Models.Adminstrations
{
	public  class TransporteurEdit: TransporteurRequest
	{
		[Range(1, int.MaxValue, ErrorMessage = MessageValidations.Erreur100)]
		public int TransporteurID { get; set; }
		List<SiteOperationRequest>  SiteOperations { get; set; }
		List<ModeTransportRequest>  ModeTransports { get; set; }
		List<ComptabiliteRequest>  Comptabilites { get; set; }
	}
}
