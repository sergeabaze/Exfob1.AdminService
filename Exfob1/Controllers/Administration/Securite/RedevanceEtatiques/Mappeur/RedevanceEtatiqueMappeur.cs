using AutoMapper;
using Exfob.Models.Administration;
using Exfob1.Models.Adminstrations;
namespace Exfob1.Controllers.Administration
{
	public class RedevanceEtatiqueMappeur : Profile
	{
		public RedevanceEtatiqueMappeur()
		{
			CreateMap<RedevanceEtatique, RedevanceEtatiqueListe>();
			CreateMap<RedevanceEtatique, RedevanceEtatiqueReponse>();
			CreateMap<RedevanceEtatiqueEdit, RedevanceEtatique>();
			CreateMap<RedevanceEtatiqueRequest, RedevanceEtatique>();
		}
	}
}
