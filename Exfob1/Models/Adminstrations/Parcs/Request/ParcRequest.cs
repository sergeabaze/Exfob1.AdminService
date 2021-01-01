using System;
using Exfob1.Communs;
using System.ComponentModel.DataAnnotations;
namespace Exfob1.Models.Adminstrations
{
	public  class ParcRequest
	{
		[Range(1, int.MaxValue, ErrorMessage = MessageValidations.Erreur100)]
		[Required(ErrorMessage = MessageValidations.Erreur100)]
		public int  SiteOperattionID { get; set; }
		[Range(1, int.MaxValue, ErrorMessage = MessageValidations.Erreur100)]
		[Required(ErrorMessage = MessageValidations.Erreur100)]
		public int  NatureParcID { get; set; }
		[Required(ErrorMessage = MessageValidations.Erreur100)]
		public string  CodeParc { get; set; }
		[Required(ErrorMessage = MessageValidations.Erreur100)]
		public string  Libelle { get; set; }
		[Required(ErrorMessage = MessageValidations.Erreur100)]
		public bool  CodeVolume { get; set; }
		[Required(ErrorMessage = MessageValidations.Erreur100)]
		public string  CodeArbre { get; set; }
		[Required(ErrorMessage = MessageValidations.Erreur100)]
		public string  CodeStockSechoir { get; set; }
		public string  CodeParcBois { get; set; }
		[Range(1, int.MaxValue, ErrorMessage = MessageValidations.Erreur100)]
		public int  LieuTransitID { get; set; }
	}
}
