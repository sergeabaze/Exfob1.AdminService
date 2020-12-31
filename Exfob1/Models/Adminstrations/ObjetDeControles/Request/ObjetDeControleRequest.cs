using System;
using Exfob1.Communs;
using System.ComponentModel.DataAnnotations;
namespace Exfob1.Models.Adminstrations
{
	public  class ObjetDeControleRequest
	{
		[Required]
		public int  ControleID { get; set; }
		public int  PeriodeID { get; set; }
		public int  TablesID { get; set; }
		public int  TypeOperationID { get; set; }
		public bool  Active { get; set; }
	}
}
