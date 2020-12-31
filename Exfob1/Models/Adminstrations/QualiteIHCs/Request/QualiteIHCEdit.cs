using System;
using System.Text;
using System.Collections.Generic;
using Exfob1.Communs;
using System.ComponentModel.DataAnnotations;
namespace Exfob1.Models.Adminstrations
{
	public  class QualiteIHCEdit: QualiteIHCRequest
	{
		[Range(1, int.MaxValue, ErrorMessage = MessageValidations.Erreur100)]
		public int QualiteIHCID { get; set; }
		List<SousFamilleRequest>  SousFamilles { get; set; }
	}
}
