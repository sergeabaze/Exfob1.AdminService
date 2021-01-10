using AutoMapper;
using Exfob.Models.Administration;
using Exfob1.Models.Adminstrations;
namespace Exfob1.Controllers.Administration
{
	public class MoyenTransportMappeur : Profile
	{
		public MoyenTransportMappeur()
		{
			CreateMap<MoyenTransport, MoyenTransportListe>();
			CreateMap<MoyenTransport, MoyenTransportReponse>();
			CreateMap<MoyenTransportEdit, MoyenTransport>();
			CreateMap<MoyenTransportRequest, MoyenTransport>();
		}
	}
}
