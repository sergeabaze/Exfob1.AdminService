using AutoMapper;
using Exfob.Models.Administration;
using Exfob1.Models.Adminstrations;
namespace Exfob1.Controllers.Administration
{
	public class CompteBanqueMappeur : Profile
	{
		public CompteBanqueMappeur()
		{
			CreateMap<CompteBanque, CompteBanqueListe>();
			CreateMap<CompteBanque, CompteBanqueReponse>();
			CreateMap<CompteBanqueEdit, CompteBanque>();
			CreateMap<CompteBanqueRequest, CompteBanque>();
		}
	}
}
