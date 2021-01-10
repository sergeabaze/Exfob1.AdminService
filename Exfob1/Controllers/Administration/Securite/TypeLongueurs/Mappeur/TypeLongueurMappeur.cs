using AutoMapper;
using Exfob.Models.Administration;
using Exfob1.Models.Adminstrations;
namespace Exfob1.Controllers.Administration
{
	public class TypeLongueurMappeur : Profile
	{
		public TypeLongueurMappeur()
		{
			CreateMap<TypeLongueur, TypeLongueurListe>();
			CreateMap<TypeLongueur, TypeLongueurReponse>();
			CreateMap<TypeLongueurEdit, TypeLongueur>();
			CreateMap<TypeLongueurRequest, TypeLongueur>();
		}
	}
}
