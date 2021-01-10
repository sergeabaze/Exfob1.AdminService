using AutoMapper;
using Exfob.Models.Administration;
using Exfob1.Models.Adminstrations;
namespace Exfob1.Controllers.Administration
{
	public class LangueMappeur : Profile
	{
		public LangueMappeur()
		{
			CreateMap<Langue, LangueListe>();
			CreateMap<Langue, LangueReponse>();
			CreateMap<LangueEdit, Langue>();
			CreateMap<LangueRequest, Langue>();
		}
	}
}
