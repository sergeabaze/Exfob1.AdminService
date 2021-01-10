using AutoMapper;
using Exfob.Models.Administration;
using Exfob1.Models.Adminstrations;
namespace Exfob1.Controllers.Administration
{
	public class TypeFournisseurMappeur : Profile
	{
		public TypeFournisseurMappeur()
		{
			CreateMap<TypeFournisseur, TypeFournisseurListe>();
			CreateMap<TypeFournisseur, TypeFournisseurReponse>();
			CreateMap<TypeFournisseurEdit, TypeFournisseur>();
			CreateMap<TypeFournisseurRequest, TypeFournisseur>();
		}
	}
}
