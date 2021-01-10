using AutoMapper;
using Exfob.Models.Administration;
using Exfob1.Models.Adminstrations;
namespace Exfob1.Controllers.Administration
{
	public class TypeEquipeMappeur : Profile
	{
		public TypeEquipeMappeur()
		{
			CreateMap<TypeEquipe, TypeEquipeListe>();
			CreateMap<TypeEquipe, TypeEquipeReponse>();
			CreateMap<TypeEquipeEdit, TypeEquipe>();
			CreateMap<TypeEquipeRequest, TypeEquipe>();
		}
	}
}
