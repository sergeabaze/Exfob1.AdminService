using System;
using Exfob1.Communs;
using System.ComponentModel.DataAnnotations;
namespace Exfob1.Models.Adminstrations
{
	public  class EquipeOperateurRequest
	{
		[Required]
		public int  OperateurID { get; set; }
		[Required]
		public int  EquipeID { get; set; }
		[Required]
		public int  TypeOperateurID { get; set; }
		[Required]
		public bool  EstResponsable { get; set; }
	}
}
