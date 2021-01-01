using System;
using Exfob1.Communs;
using System.ComponentModel.DataAnnotations;
namespace Exfob1.Models.Adminstrations
{
	public  class StockArbreForetRequest
	{
		[Range(1, int.MaxValue, ErrorMessage = MessageValidations.Erreur100)]
		[Required(ErrorMessage = MessageValidations.Erreur100)]
		public int  TrackingID { get; set; }
		[Range(1, int.MaxValue, ErrorMessage = MessageValidations.Erreur100)]
		[Required(ErrorMessage = MessageValidations.Erreur100)]
		public int  TronconnageParcID { get; set; }
		[Range(1, int.MaxValue, ErrorMessage = MessageValidations.Erreur100)]
		[Required(ErrorMessage = MessageValidations.Erreur100)]
		public int  NatureMouvementID { get; set; }
		[Range(1, int.MaxValue, ErrorMessage = MessageValidations.Erreur100)]
		[Required(ErrorMessage = MessageValidations.Erreur100)]
		public int  CategorieBoisID { get; set; }
		[Range(1, int.MaxValue, ErrorMessage = MessageValidations.Erreur100)]
		[Required(ErrorMessage = MessageValidations.Erreur100)]
		public int  MotifID { get; set; }
		public string  SequenceNumeroForet { get; set; }
		[Range(1, int.MaxValue, ErrorMessage = MessageValidations.Erreur100)]
		public int  NumeroForestier { get; set; }
		public string  SequenceNumeroForet2 { get; set; }
		[Range(1, int.MaxValue, ErrorMessage = MessageValidations.Erreur100)]
		public int  DiametreGrosBoutBille1 { get; set; }
		[Range(1, int.MaxValue, ErrorMessage = MessageValidations.Erreur100)]
		public int  DiametreGrosBoutBille2 { get; set; }
		[Range(1, int.MaxValue, ErrorMessage = MessageValidations.Erreur100)]
		public int  DiametrePetitBoutBille1 { get; set; }
		[Range(1, int.MaxValue, ErrorMessage = MessageValidations.Erreur100)]
		public int  DiametrePetitBoutBille2 { get; set; }
		[Range(1, int.MaxValue, ErrorMessage = MessageValidations.Erreur100)]
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
