using AutoMapper;
using Exfob.Models.Administration;
using Exfob1.Models.Adminstrations;
namespace Exfob1.Controllers.Administration
{
	public class EquipeOperateurMappeur : Profile
	{
		public EquipeOperateurMappeur()
		{
			CreateMap<EquipeOperateur, EquipeOperateurListe>();
			CreateMap<EquipeOperateur, EquipeOperateurReponse>();
			CreateMap<EquipeOperateurEdit, EquipeOperateur>();
			CreateMap<EquipeOperateurRequest, EquipeOperateur>();
		}
	}
}
