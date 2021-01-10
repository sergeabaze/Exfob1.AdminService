using AutoMapper;
using Exfob.Models.Administration;
using Exfob1.Models.Adminstrations;
namespace Exfob1.Controllers.Administration
{
	public class TypeMaterielMappeur : Profile
	{
		public TypeMaterielMappeur()
		{
			CreateMap<TypeMateriel, TypeMaterielListe>();
			CreateMap<TypeMateriel, TypeMaterielReponse>();
			CreateMap<TypeMaterielEdit, TypeMateriel>();
			CreateMap<TypeMaterielRequest, TypeMateriel>();
		}
	}
}
