using AutoMapper;
using Exfob.Models.Administration;
using Exfob1.Models.Adminstrations;
namespace Exfob1.Controllers.Administration
{
	public class SiteAutoriseMappeur : Profile
	{
		public SiteAutoriseMappeur()
		{
			CreateMap<SiteAutorise, SiteAutoriseListe>();
			CreateMap<SiteAutorise, SiteAutoriseReponse>();
			CreateMap<SiteAutoriseEdit, SiteAutorise>();
			CreateMap<SiteAutoriseRequest, SiteAutorise>();
		}
	}
}
