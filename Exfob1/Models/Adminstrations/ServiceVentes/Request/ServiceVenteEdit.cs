using System;
using System.Collections.Generic;
using Exfob1.Communs;
using System.ComponentModel.DataAnnotations;
namespace Exfob1.Models.Adminstrations
{
	public  class ServiceVenteEdit: ServiceVenteRequest
	{
		[Range(1, int.MaxValue, ErrorMessage = MessageValidations.Erreur100)]
		public int ServiceVenteID { get; set; }
	}
}
