using AutoMapper;
using Exfob.Models.Administration;
using Exfob1.Models.Adminstrations;
namespace Exfob1.Controllers.Administration
{
	public class PortArriveMappeur : Profile
	{
		public PortArriveMappeur()
		{
			CreateMap<PortArrive, PortArriveListe>();
			CreateMap<PortArrive, PortArriveReponse>();
			CreateMap<PortArriveEdit, PortArrive>();
			CreateMap<PortArriveRequest, PortArrive>();
		}
	}
}
