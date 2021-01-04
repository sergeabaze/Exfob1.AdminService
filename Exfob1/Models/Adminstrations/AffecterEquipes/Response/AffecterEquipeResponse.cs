using System;
namespace Exfob1.Models.Adminstrations
{
	public  class AffecterEquipeReponse
	{

		public int  AffecterEquipeID { get; set; }
		public int  TrancheHoraireID { get; set; }
		public int  OperateurID { get; set; }
		public int  EquipeID { get; set; }
		public bool  EstChefEquipe { get; set; }
		public DateTime  DateOperation { get; set; }
		public bool  EstResponsable { get; set; }
	}
}
