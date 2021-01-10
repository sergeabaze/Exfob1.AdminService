using AutoMapper;
using Exfob.Models.Administration;
using Exfob1.Models.Adminstrations;
namespace Exfob1.Controllers.Administration
{
	public class SocieteMappeur : Profile
	{
		public SocieteMappeur()
		{
			CreateMap<Societe, SocieteListe>();
			CreateMap<Societe, SocieteReponse>();
			CreateMap<SocieteEdit, Societe>();
			CreateMap<SocieteRequest, Societe>();
		}
	}
}
