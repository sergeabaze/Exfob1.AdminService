using System;
using System.Text;
using System.Collections.Generic;
using Exfob1.Communs;
using System.ComponentModel.DataAnnotations;
namespace Exfob1.Models.Adminstrations
{
	public  class ListeServiceVenteEdit: ListeServiceVenteRequest
	{
		[Range(1, int.MaxValue, ErrorMessage = MessageValidations.Erreur100)]
		public int ListeServiceVenteID { get; set; }
		List<SocieteRequest>  Societes { get; set; }
	}
}
