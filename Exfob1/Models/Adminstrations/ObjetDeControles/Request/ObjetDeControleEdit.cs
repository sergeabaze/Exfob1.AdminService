using System;
using System.Text;
using System.Collections.Generic;
using Exfob1.Communs;
using System.ComponentModel.DataAnnotations;
namespace Exfob1.Models.Adminstrations
{
	public  class ObjetDeControleEdit: ObjetDeControleRequest
	{
		[Range(1, int.MaxValue, ErrorMessage = MessageValidations.Erreur100)]
		public int ObjetDeControleID { get; set; }
		/*List<ControleRequest>  Controles { get; set; }
		List<PeriodeRequest>  Periodes { get; set; }
		List<TablesRequest>  Tabless { get; set; }
		List<TypeOperationRequest>  TypeOperations { get; set; }*/
	}
}
