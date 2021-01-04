using System;
using Exfob1.Communs;
using System.ComponentModel.DataAnnotations;
namespace Exfob1.Models.Adminstrations
{
	public  class PortRequest
	{
		[Required]
		public int  SocieteID { get; set; }
		[Required]
		public int  NaturePortID { get; set; }
		[Required]
		public string  Libelle { get; set; }
		public string  Numerodestination { get; set; }
		[Required]
		public bool  EstActif { get; set; }
		public int  Phyto { get; set; }
		public int  Co { get; set; }
		public int  Eur1 { get; set; }
		public int  PaysID { get; set; }
		public int  ParcID { get; set; }
	}
}
