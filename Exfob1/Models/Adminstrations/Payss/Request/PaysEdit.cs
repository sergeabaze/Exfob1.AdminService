using System;
using System.Collections.Generic;
using Exfob1.Communs;
using System.ComponentModel.DataAnnotations;
namespace Exfob1.Models.Adminstrations
{
	public  class PaysEdit: PaysRequest
	{
		[Range(1, int.MaxValue, ErrorMessage = MessageValidations.Erreur100)]
		public int PaysID { get; set; }
	}
}
