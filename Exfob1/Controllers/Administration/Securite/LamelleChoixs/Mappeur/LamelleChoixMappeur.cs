using AutoMapper;
using Exfob.Models.Administration;
using Exfob1.Models.Adminstrations;
namespace Exfob1.Controllers.Administration
{
	public class LamelleChoixMappeur : Profile
	{
		public LamelleChoixMappeur()
		{
			CreateMap<LamelleChoix, LamelleChoixListe>();
			CreateMap<LamelleChoix, LamelleChoixReponse>();
			CreateMap<LamelleChoixEdit, LamelleChoix>();
			CreateMap<LamelleChoixRequest, LamelleChoix>();
		}
	}
}
