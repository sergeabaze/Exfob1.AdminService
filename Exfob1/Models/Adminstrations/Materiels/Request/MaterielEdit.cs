using System;
using System.Text;
using System.Collections.Generic;
using Exfob1.Communs;
using System.ComponentModel.DataAnnotations;
namespace Exfob1.Models.Adminstrations
{
	public  class MaterielEdit: MaterielRequest
	{
		[Range(1, int.MaxValue, ErrorMessage = MessageValidations.Erreur100)]
		public int MaterielID { get; set; }
		List<SiteOperationRequest>  SiteOperations { get; set; }
		List<SousTraitanceRequest>  SousTraitances { get; set; }
	}
}
