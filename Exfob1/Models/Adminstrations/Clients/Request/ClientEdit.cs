using System;
using System.Text;
using System.Collections.Generic;
using Exfob1.Communs;
using System.ComponentModel.DataAnnotations;
namespace Exfob1.Models.Adminstrations
{
	public  class ClientEdit: ClientRequest
	{
		[Range(1, int.MaxValue, ErrorMessage = MessageValidations.Erreur100)]
		public int ClientID { get; set; }
		List<SiteOperationRequest>  SiteOperations { get; set; }
		List<SiegeRequest>  Sieges { get; set; }
		List<TypeClientRequest>  Typeclients { get; set; }
		List<PaysRequest>  Payss { get; set; }
		List<VilleRequest>  Villes { get; set; }
	}
}
