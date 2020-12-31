using System;
using System.Text;
using System.Collections.Generic;
using Exfob1.Communs;
using System.ComponentModel.DataAnnotations;
using Exfob1.Models.Adminstrations.Utilisateurs.Request;

namespace Exfob1.Models.Adminstrations
{
	public  class SiteAutoriseEdit: SiteAutoriseRequest
	{
		[Range(1, int.MaxValue, ErrorMessage = MessageValidations.Erreur100)]
		public int SiteAutoriseID { get; set; }
		List<SiteOperationRequest>  SiteOperations { get; set; }
		List<UtilisateurRequestCreate>  Utilisateurs { get; set; }
		List<ProfilAutoriseRequest>  ProfilAutorises { get; set; }
	}
}
