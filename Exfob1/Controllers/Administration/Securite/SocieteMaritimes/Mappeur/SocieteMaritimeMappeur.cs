using AutoMapper;
using Exfob.Models.Administration;
using Exfob1.Models.Adminstrations;
namespace Exfob1.Controllers.Administration
{
	public class SocieteMaritimeMappeur : Profile
	{
		public SocieteMaritimeMappeur()
		{
			CreateMap<SocieteMaritime, SocieteMaritimeListe>();
			CreateMap<SocieteMaritime, SocieteMaritimeReponse>();
			CreateMap<SocieteMaritimeEdit, SocieteMaritime>();
			CreateMap<SocieteMaritimeRequest, SocieteMaritime>();
		}
	}
}
