using AutoMapper;
using Exfob.Models.Administration;
using Exfob1.Models.Adminstrations;
namespace Exfob1.Controllers.Administration
{
	public class PortMappeur : Profile
	{
		public PortMappeur()
		{
			CreateMap<Port, PortListe>();
			CreateMap<Port, PortReponse>();
			CreateMap<PortEdit, Port>();
			CreateMap<PortRequest, Port>();
		}
	}
}
