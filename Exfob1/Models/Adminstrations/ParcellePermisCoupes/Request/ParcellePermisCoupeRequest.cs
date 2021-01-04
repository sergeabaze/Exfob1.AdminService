using System;
using Exfob1.Communs;
using System.ComponentModel.DataAnnotations;
namespace Exfob1.Models.Adminstrations
{
	public  class ParcellePermisCoupeRequest
	{
		public int  ChantierID { get; set; }
		public string  NumeroParcelle { get; set; }
		public Decimal  CoordonneeX { get; set; }
		public Decimal  CoordonneeY { get; set; }
		public Decimal  SuperficieParcelle { get; set; }
		public string  NomX { get; set; }
		public string  NomY { get; set; }
		[Required]
		public DateTime  DateCreation { get; set; }
		[Required]
		public string  CreerPar { get; set; }
		public DateTime  DateModification { get; set; }
		public string  MisejourPar { get; set; }
	}
}
