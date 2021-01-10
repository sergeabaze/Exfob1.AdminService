using AutoMapper;
using Exfob.Models.Administration;
using Exfob1.Models.Adminstrations;
namespace Exfob1.Controllers.Administration
{
	public class NavireMappeur : Profile
	{
		public NavireMappeur()
		{
			CreateMap<Navire, NavireListe>();
			CreateMap<Navire, NavireReponse>();
			CreateMap<NavireEdit, Navire>();
			CreateMap<NavireRequest, Navire>();
		}
	}
}
