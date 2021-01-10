using AutoMapper;
using Exfob.Models.Administration;
using Exfob1.Models.Adminstrations;
namespace Exfob1.Controllers.Administration
{
	public class SiegeMappeur : Profile
	{
		public SiegeMappeur()
		{
			CreateMap<Siege, SiegeListe>();
			CreateMap<Siege, SiegeReponse>();
			CreateMap<SiegeEdit, Siege>();
			CreateMap<SiegeRequest, Siege>();
		}
	}
}
