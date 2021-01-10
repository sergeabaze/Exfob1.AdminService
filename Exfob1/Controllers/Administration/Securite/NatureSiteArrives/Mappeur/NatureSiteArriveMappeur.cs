using AutoMapper;
using Exfob.Models.Administration;
using Exfob1.Models.Adminstrations;
namespace Exfob1.Controllers.Administration
{
	public class NatureSiteArriveMappeur : Profile
	{
		public NatureSiteArriveMappeur()
		{
			CreateMap<NatureSiteArrive, NatureSiteArriveListe>();
			CreateMap<NatureSiteArrive, NatureSiteArriveReponse>();
			CreateMap<NatureSiteArriveEdit, NatureSiteArrive>();
			CreateMap<NatureSiteArriveRequest, NatureSiteArrive>();
		}
	}
}
