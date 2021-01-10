using AutoMapper;
using Exfob.Models.Administration;
using Exfob1.Models.Adminstrations;
namespace Exfob1.Controllers.Administration
{
	public class ProduitMappeur : Profile
	{
		public ProduitMappeur()
		{
			CreateMap<Produit, ProduitListe>();
			CreateMap<Produit, ProduitReponse>();
			CreateMap<ProduitEdit, Produit>();
			CreateMap<ProduitRequest, Produit>();
		}
	}
}
