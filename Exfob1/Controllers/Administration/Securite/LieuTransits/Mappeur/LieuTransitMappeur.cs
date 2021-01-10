using AutoMapper;
using Exfob.Models.Administration;
using Exfob1.Models.Adminstrations;
namespace Exfob1.Controllers.Administration
{
	public class LieuTransitMappeur : Profile
	{
		public LieuTransitMappeur()
		{
			CreateMap<LieuTransit, LieuTransitListe>();
			CreateMap<LieuTransit, LieuTransitReponse>();
			CreateMap<LieuTransitEdit, LieuTransit>();
			CreateMap<LieuTransitRequest, LieuTransit>();
		}
	}
}
