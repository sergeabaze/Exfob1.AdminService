using AutoMapper;
using Exfob.Models.Administration;
using Exfob1.Models.Adminstrations;
namespace Exfob1.Controllers.Administration
{
	public class EssenceMappeur : Profile
	{
		public EssenceMappeur()
		{
			CreateMap<Essence, EssenceListe>();
			CreateMap<Essence, EssenceReponse>();
			CreateMap<EssenceEdit, Essence>();
			CreateMap<EssenceRequest, Essence>();
		}
	}
}
