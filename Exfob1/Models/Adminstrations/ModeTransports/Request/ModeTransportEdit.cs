using System;
using System.Collections.Generic;
using Exfob1.Communs;
using System.ComponentModel.DataAnnotations;
namespace Exfob1.Models.Adminstrations
{
	public  class ModeTransportEdit: ModeTransportRequest
	{
		[Range(1, int.MaxValue, ErrorMessage = MessageValidations.Erreur100)]
		public int ModeTransportID { get; set; }
	}
}
