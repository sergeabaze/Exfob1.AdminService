using System;
namespace Exfob1.Models.Adminstrations
{
	public  class PortListe
	{
		public int  PortID { get; set; }
		public int  SocieteID { get; set; }
		public int  NaturePortID { get; set; }
		public string  Libelle { get; set; }
		public string  Numerodestination { get; set; }
		public bool  EstActif { get; set; }
		public int  Phyto { get; set; }
		public int  Co { get; set; }
		public int  Eur1 { get; set; }
		public int  PaysID { get; set; }
		public int  ParcID { get; set; }
	}
}
