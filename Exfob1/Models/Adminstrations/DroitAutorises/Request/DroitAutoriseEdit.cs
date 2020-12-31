using System;
using System.Text;
using System.Collections.Generic;
using Exfob1.Communs;
using System.ComponentModel.DataAnnotations;
namespace Exfob1.Models.Adminstrations
{
	public  class DroitAutoriseEdit: DroitAutoriseRequest
	{
		[Range(1, int.MaxValue, ErrorMessage = MessageValidations.Erreur100)]
		public int DroitAutoriseID { get; set; }
		List<ProfilAutoriseRequest>  ProfilAutorises { get; set; }
		List<ModuleRequest>  Modules { get; set; }
	}
}
