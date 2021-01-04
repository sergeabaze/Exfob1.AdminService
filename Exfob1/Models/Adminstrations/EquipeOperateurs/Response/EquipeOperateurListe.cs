using System;
namespace Exfob1.Models.Adminstrations
{
	public  class EquipeOperateurListe
	{
		public int  OperateurID { get; set; }
		public int  EquipeID { get; set; }
		public int  TypeOperateurID { get; set; }
		public bool  EstResponsable { get; set; }
	}
}
