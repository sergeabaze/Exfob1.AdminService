using System;
using System.Text;
using System.Collections.Generic;
using Exfob1.Communs;
using System.ComponentModel.DataAnnotations;
namespace Exfob1.Models.Adminstrations
{
	public  class SciesEdit: SciesRequest
	{
		[Range(1, int.MaxValue, ErrorMessage = MessageValidations.Erreur100)]
		public int SciesID { get; set; }
		List<SocieteRequest>  Societes { get; set; }
		List<EquipeRequest>  Equipes { get; set; }
	}
}
