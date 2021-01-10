using AutoMapper;
using Exfob.Models.Administration;
using Exfob1.Models.Adminstrations;
namespace Exfob1.Controllers.Administration
{
	public class TerminalPortMappeur : Profile
	{
		public TerminalPortMappeur()
		{
			CreateMap<TerminalPort, TerminalPortListe>();
			CreateMap<TerminalPort, TerminalPortReponse>();
			CreateMap<TerminalPortEdit, TerminalPort>();
			CreateMap<TerminalPortRequest, TerminalPort>();
		}
	}
}
