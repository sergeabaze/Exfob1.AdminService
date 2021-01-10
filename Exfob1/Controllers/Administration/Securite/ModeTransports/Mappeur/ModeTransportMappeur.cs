using AutoMapper;
using Exfob.Models.Administration;
using Exfob1.Models.Adminstrations;
namespace Exfob1.Controllers.Administration
{
	public class ModeTransportMappeur : Profile
	{
		public ModeTransportMappeur()
		{
			CreateMap<ModeTransport, ModeTransportListe>();
			CreateMap<ModeTransport, ModeTransportReponse>();
			CreateMap<ModeTransportEdit, ModeTransport>();
			CreateMap<ModeTransportRequest, ModeTransport>();
		}
	}
}
