using System;
namespace Exfob1.Models.Adminstrations
{
	public  class StockArbreForetListe
	{
		public int  StockArbreForetID { get; set; }
		public int  TrackingID { get; set; }
		public int  TronconnageParcID { get; set; }
		public int  NatureMouvementID { get; set; }
		public int  CategorieBoisID { get; set; }
		public int  MotifID { get; set; }
		public string  SequenceNumeroForet { get; set; }
		public int  NumeroForestier { get; set; }
		public string  SequenceNumeroForet2 { get; set; }
		public int  DiametreGrosBoutBille1 { get; set; }
		public int  DiametreGrosBoutBille2 { get; set; }
		public int  DiametrePetitBoutBille1 { get; set; }
		public int  DiametrePetitBoutBille2 { get; set; }
		public int  DiametreMoyenneBille { get; set; }
		public float  LongueurBille { get; set; }
		public float  VolumeBille { get; set; }
		public string  Observation { get; set; }
		public DateTime  DateSortie { get; set; }
		public string  NumeroParc { get; set; }
		public string  CreerPar { get; set; }
		public DateTime  DateCreation { get; set; }
		public string  MiseAjourPar { get; set; }
		public DateTime  DateModification { get; set; }
	}
}
