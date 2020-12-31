using System;
namespace Exfob1.Models.Adminstrations
{
	public  class EquipeOperateurReponse
	{

		public int  OperateurID { get; set; }
		public int  EquipeID { get; set; }
		public int  TypeOperateurID { get; set; }
		public bool  EstResponsable { get; set; }
	}
}
