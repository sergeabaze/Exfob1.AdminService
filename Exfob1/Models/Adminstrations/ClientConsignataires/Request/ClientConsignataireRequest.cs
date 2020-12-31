using System;
using Exfob1.Communs;
using System.ComponentModel.DataAnnotations;
namespace Exfob1.Models.Adminstrations
{
	public  class ClientConsignataireRequest
	{
		public int  MaterielID { get; set; }
		[Required]
		public int  ClientID { get; set; }
		[Required]
		public string  Code { get; set; }
		[Required]
		public string  NomConsignataire { get; set; }
	}
}
