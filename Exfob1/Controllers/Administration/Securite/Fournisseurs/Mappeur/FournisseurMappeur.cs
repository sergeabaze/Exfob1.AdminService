using AutoMapper;
using Exfob.Models.Administration;
using Exfob1.Models.Adminstrations;
namespace Exfob1.Controllers.Administration
{
	public class FournisseurMappeur : Profile
	{
		public FournisseurMappeur()
		{
			CreateMap<Fournisseur, FournisseurListe>();
			CreateMap<Fournisseur, FournisseurReponse>();
			CreateMap<FournisseurEdit, Fournisseur>();
			CreateMap<FournisseurRequest, Fournisseur>();
		}
	}
}
