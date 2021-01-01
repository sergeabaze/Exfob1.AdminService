using System;
using System.Collections.Generic;
using Exfob1.Communs;
using System.ComponentModel.DataAnnotations;
namespace Exfob1.Models.Adminstrations
{
	public  class NavireEdit: NavireRequest
	{
		[Range(1, int.MaxValue, ErrorMessage = MessageValidations.Erreur100)]
		public int NavireID { get; set; }
	}
}
