using System;
using Exfob1.Communs;
using System.ComponentModel.DataAnnotations;
namespace Exfob1.Models.Adminstrations
{
	public  class SepbcRequest
	{
		public int  PortID { get; set; }
		public string  Code { get; set; }
		public string  Libelle { get; set; }
	}
}
