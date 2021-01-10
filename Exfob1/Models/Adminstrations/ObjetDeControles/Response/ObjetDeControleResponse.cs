using System;
namespace Exfob1.Models.Adminstrations
{
	public  class ObjetDeControleReponse
	{

		public int  ControleID { get; set; }
		public int  PeriodeID { get; set; }
		public int  TablesID { get; set; }
		public int  TypeOperationID { get; set; }
		public bool  Active { get; set; }
	}
}
