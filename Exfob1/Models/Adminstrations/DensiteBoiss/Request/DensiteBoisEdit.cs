using System;
using System.Text;
using System.Collections.Generic;
using Exfob1.Communs;
using System.ComponentModel.DataAnnotations;
namespace Exfob1.Models.Adminstrations
{
	public  class DensiteBoisEdit: DensiteBoisRequest
	{
		[Range(1, int.MaxValue, ErrorMessage = MessageValidations.Erreur100)]
		public int DensiteBoisID { get; set; }
		List<EssenceRequest>  Essences { get; set; }
		List<ProduitRequest>  Produits { get; set; }
	}
}
