using AutoMapper;
using Exfob.Models.Administration;
using Exfob1.Models.Adminstrations;
namespace Exfob1.Controllers.Administration
{
	public class EquipeMappeur : Profile
	{
		public EquipeMappeur()
		{
			CreateMap<Equipe, EquipeListe>();
			CreateMap<Equipe, EquipeReponse>();
			CreateMap<EquipeEdit, Equipe>();
			CreateMap<EquipeRequest, Equipe>();
		}
	}
}
