using AutoMapper;
using Exfob.Models.Administration;
using Exfob1.Models.Adminstrations;
namespace Exfob1.Controllers.Administration
{
	public class ChantierMappeur : Profile
	{
		public ChantierMappeur()
		{
			CreateMap<Chantier, ChantierListe>();
			CreateMap<Chantier, ChantierReponse>();
			CreateMap<ChantierEdit, Chantier>();
			CreateMap<ChantierRequest, Chantier>();
		}
	}
}
