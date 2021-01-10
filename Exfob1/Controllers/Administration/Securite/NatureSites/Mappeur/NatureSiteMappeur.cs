using AutoMapper;
using Exfob.Models.Administration;
using Exfob1.Models.Adminstrations;
namespace Exfob1.Controllers.Administration
{
	public class NatureSiteMappeur : Profile
	{
		public NatureSiteMappeur()
		{
			CreateMap<NatureSite, NatureSiteListe>();
			CreateMap<NatureSite, NatureSiteReponse>();
			CreateMap<NatureSiteEdit, NatureSite>();
			CreateMap<NatureSiteRequest, NatureSite>();
		}
	}
}
