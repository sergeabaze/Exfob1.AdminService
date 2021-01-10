using AutoMapper;
using Exfob.Models.Administration;
using Exfob1.Models.Adminstrations;
namespace Exfob1.Controllers.Administration
{
	public class AffecterEquipeMappeur : Profile
	{
		public AffecterEquipeMappeur()
		{
			CreateMap<AffecterEquipe, AffecterEquipeListe>();
			CreateMap<AffecterEquipe, AffecterEquipeReponse>();
			CreateMap<AffecterEquipeEdit, AffecterEquipe>();
			CreateMap<AffecterEquipeRequest, AffecterEquipe>();
		}
	}
}
