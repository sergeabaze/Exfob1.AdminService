using AutoMapper;
using Exfob.Models.Administration;
using Exfob1.Models.Adminstrations;
namespace Exfob1.Controllers.Administration
{
	public class ProfilAutoriseMappeur : Profile
	{
		public ProfilAutoriseMappeur()
		{
			CreateMap<ProfilAutorise, ProfilAutoriseListe>();
			CreateMap<ProfilAutorise, ProfilAutoriseReponse>();
			CreateMap<ProfilAutoriseEdit, ProfilAutorise>();
			CreateMap<ProfilAutoriseRequest, ProfilAutorise>();
		}
	}
}
