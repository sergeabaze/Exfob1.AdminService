using System;
using System.Text;
using System.Collections.Generic;
using Exfob1.Communs;
using System.ComponentModel.DataAnnotations;
namespace Exfob1.Models.Adminstrations
{
	public  class CodePlaquetteEdit: CodePlaquetteRequest
	{
		[Range(1, int.MaxValue, ErrorMessage = MessageValidations.Erreur100)]
		public int CodePlaquetteID { get; set; }
		List<SiteOperationRequest>  SiteOperations { get; set; }
		List<QualiteBoisRequest>  QualiteBoiss { get; set; }
		List<SciesRequest>  Sciess { get; set; }
		List<TypeLongueurRequest>  TypeLongueurs { get; set; }
	}
}
