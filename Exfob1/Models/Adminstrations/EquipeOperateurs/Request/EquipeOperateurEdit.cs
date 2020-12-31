using System;
using System.Text;
using System.Collections.Generic;
using Exfob1.Communs;
using System.ComponentModel.DataAnnotations;
namespace Exfob1.Models.Adminstrations
{
	public  class EquipeOperateurEdit: EquipeOperateurRequest
	{
		[Range(1, int.MaxValue, ErrorMessage = MessageValidations.Erreur100)]
		public int EquipeOperateurID { get; set; }
		List<OperateurRequest>  Operateurs { get; set; }
		List<EquipeRequest>  Equipes { get; set; }
		List<TypeOperateurRequest>  TypeOperateurs { get; set; }
	}
}
