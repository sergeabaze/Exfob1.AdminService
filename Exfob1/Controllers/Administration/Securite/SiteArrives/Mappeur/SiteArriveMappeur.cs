using AutoMapper;
using Exfob.Models.Administration;
using Exfob1.Models.Adminstrations;
namespace Exfob1.Controllers.Administration
{
	public class SiteArriveMappeur : Profile
	{
		public SiteArriveMappeur()
		{
			CreateMap<SiteArrive, SiteArriveListe>();
			CreateMap<SiteArrive, SiteArriveReponse>();
			CreateMap<SiteArriveEdit, SiteArrive>();
			CreateMap<SiteArriveRequest, SiteArrive>();
		}
	}
}
