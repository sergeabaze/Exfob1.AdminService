using System;
using System.Text;
using System.Collections.Generic;
using Exfob1.Communs;
using System.ComponentModel.DataAnnotations;
namespace Exfob1.Models.Adminstrations
{
	public  class ClientContactEdit: ClientContactRequest
	{
		[Range(1, int.MaxValue, ErrorMessage = MessageValidations.Erreur100)]
		public int ClientContactID { get; set; }
		List<ClientRequest>  Clients { get; set; }
		List<ClientAdresseRequest>  ClientAdresses { get; set; }
	}
}
