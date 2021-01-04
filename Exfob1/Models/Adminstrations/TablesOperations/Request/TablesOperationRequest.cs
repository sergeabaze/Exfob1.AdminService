using System;
using Exfob1.Communs;
using System.ComponentModel.DataAnnotations;
namespace Exfob1.Models.Adminstrations
{
	public  class TablesOperationRequest
	{
		[Required]
		public int  TablesID { get; set; }
		public int  SocieteID { get; set; }
		public string  Libelle { get; set; }
		public bool  Active { get; set; }
	}
}
