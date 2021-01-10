using AutoMapper;
using Exfob.Models.Administration;
using Exfob1.Models.Adminstrations;
namespace Exfob1.Controllers.Administration
{
	public class TypeOperateurMappeur : Profile
	{
		public TypeOperateurMappeur()
		{
			CreateMap<TypeOperateur, TypeOperateurListe>();
			CreateMap<TypeOperateur, TypeOperateurReponse>();
			CreateMap<TypeOperateurEdit, TypeOperateur>();
			CreateMap<TypeOperateurRequest, TypeOperateur>();
		}
	}
}
