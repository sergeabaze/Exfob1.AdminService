using System;
using Exfob1.Communs;
using System.ComponentModel.DataAnnotations;
namespace Exfob1.Models.Adminstrations
{
	public  class DensiteBoisRequest
	{
		[Required]
		public int  EssenceID { get; set; }
		[Required]
		public int  ProduitID { get; set; }
		[Required]
		public float  Libelle { get; set; }
	}
}
