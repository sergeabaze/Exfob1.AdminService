using AutoMapper;
using Exfob.Models.Administration;
using Exfob1.Models.Adminstrations;
namespace Exfob1.Controllers.Administration
{
	public class ModeEnvoieMappeur : Profile
	{
		public ModeEnvoieMappeur()
		{
			CreateMap<ModeEnvoie, ModeEnvoieListe>();
			CreateMap<ModeEnvoie, ModeEnvoieReponse>();
			CreateMap<ModeEnvoieEdit, ModeEnvoie>();
			CreateMap<ModeEnvoieRequest, ModeEnvoie>();
		}
	}
}
