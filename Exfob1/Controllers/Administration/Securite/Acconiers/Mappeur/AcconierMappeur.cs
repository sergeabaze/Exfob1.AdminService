using AutoMapper;
using Exfob.Models.Administration;
using Exfob1.Models.Adminstrations;
namespace Exfob1.Controllers.Administration
{
	public class AcconierMappeur : Profile
	{
		public AcconierMappeur()
		{
			CreateMap<Acconier, AcconierListe>();
			CreateMap<Acconier, AcconierReponse>();
			CreateMap<AcconierEdit, Acconier>();
			CreateMap<AcconierRequest, Acconier>();
		}
	}
}
