using AutoMapper;
using Exfob.Models.Administration;
using Exfob1.Models.Adminstrations;
namespace Exfob1.Controllers.Administration
{
	public class DroitAutoriseMappeur : Profile
	{
		public DroitAutoriseMappeur()
		{
			CreateMap<DroitAutorise, DroitAutoriseListe>();
			CreateMap<DroitAutorise, DroitAutoriseReponse>();
			CreateMap<DroitAutoriseEdit, DroitAutorise>();
			CreateMap<DroitAutoriseRequest, DroitAutorise>();
		}
	}
}
