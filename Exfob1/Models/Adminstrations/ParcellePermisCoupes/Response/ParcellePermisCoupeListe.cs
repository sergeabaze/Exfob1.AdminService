using System;
namespace Exfob1.Models.Adminstrations
{
	public  class ParcellePermisCoupeListe
	{
		public int  ParcellePermisCoupeID { get; set; }
		public int  ChantierID { get; set; }
		public string  NumeroParcelle { get; set; }
		public Decimal  CoordonneeX { get; set; }
		public Decimal  CoordonneeY { get; set; }
		public Decimal  SuperficieParcelle { get; set; }
		public string  NomX { get; set; }
		public string  NomY { get; set; }
		public DateTime  DateCreation { get; set; }
		public string  CreerPar { get; set; }
		public DateTime  DateModification { get; set; }
		public string  MisejourPar { get; set; }
	}
}
