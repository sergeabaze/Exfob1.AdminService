using System;
using System.Text;
using System.Collections.Generic;
using Exfob1.Communs;
using System.ComponentModel.DataAnnotations;
namespace Exfob1.Models.Adminstrations
{
	public  class TarifIHCEdit: TarifIHCRequest
	{
		[Range(1, int.MaxValue, ErrorMessage = MessageValidations.Erreur100)]
		public int TarifIHCID { get; set; }
		List<SocieteRequest>  Societes { get; set; }
		List<EssenceRequest>  Essences { get; set; }
		List<ProduitRequest>  Produits { get; set; }
		List<QualiteIHCRequest>  QualiteIHCs { get; set; }
	}
}
