using System;
using System.Text;
using System.Collections.Generic;
using Exfob1.Communs;
using System.ComponentModel.DataAnnotations;
namespace Exfob1.Models.Adminstrations
{
	public  class ClientConsignataireEdit: ClientConsignataireRequest
	{
		[Range(1, int.MaxValue, ErrorMessage = MessageValidations.Erreur100)]
		public int ClientConsignataireID { get; set; }
		List<MaterielRequest>  Materiels { get; set; }
		List<ClientRequest>  Clients { get; set; }
	}
}
