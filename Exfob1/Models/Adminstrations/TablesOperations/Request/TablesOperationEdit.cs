using System;
using System.Text;
using System.Collections.Generic;
using Exfob1.Communs;
using System.ComponentModel.DataAnnotations;
namespace Exfob1.Models.Adminstrations
{
	public  class TablesOperationEdit: TablesOperationRequest
	{
		[Range(1, int.MaxValue, ErrorMessage = MessageValidations.Erreur100)]
		public int TablesOperationID { get; set; }
		//List<TablesRequest>  Tabless { get; set; }
		List<SocieteRequest>  Societes { get; set; }
	}
}
