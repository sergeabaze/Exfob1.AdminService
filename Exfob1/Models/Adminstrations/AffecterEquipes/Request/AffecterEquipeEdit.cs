using System;
using System.Text;
using System.Collections.Generic;
using Exfob1.Communs;
using System.ComponentModel.DataAnnotations;
namespace Exfob1.Models.Adminstrations
{
	public  class AffecterEquipeEdit: AffecterEquipeRequest
	{
		[Range(1, int.MaxValue, ErrorMessage = MessageValidations.Erreur100)]
		public int AffecterEquipeID { get; set; }
		List<TrancheHoraireRequest>  TrancheHoraires { get; set; }
		List<OperateurRequest>  Operateurs { get; set; }
		List<EquipeRequest>  Equipes { get; set; }
	}
}
