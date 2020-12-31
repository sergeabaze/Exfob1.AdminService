using System;
using System.Text;
using System.Collections.Generic;
using Exfob1.Communs;
using System.ComponentModel.DataAnnotations;
namespace Exfob1.Models.Adminstrations
{
	public  class RotationEdit: RotationRequest
	{
		[Range(1, int.MaxValue, ErrorMessage = MessageValidations.Erreur100)]
		public int RotationID { get; set; }
		List<SiteOperationRequest>  SiteOperations { get; set; }
		List<EquipeRequest>  Equipes { get; set; }
		List<TrancheHoraireRequest>  TrancheHoraires { get; set; }
		List<SciesRequest>  Sciess { get; set; }
	}
}
